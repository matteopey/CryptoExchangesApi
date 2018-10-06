using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchangesApi
{
    /// <summary>
    /// Download data from the APIs.
    /// </summary>
    class DownloadDataLiqui : DownloadData
    {
        private readonly string endpoint;
        private readonly string absolutePath;

        public DownloadDataLiqui(string endpoint, string absolutePath) : base(endpoint,
            absolutePath)
        {
            this.endpoint = endpoint;
            this.absolutePath = absolutePath;
        }

        /// <summary>
        /// Create URL to use. Overrides the base method, because Liqui don't work with
        /// url-encoded urls.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override async Task<Uri> CreateUrl(string method,
            Maybe<FormUrlEncodedContent> parameters)
        {
            // Create uri with correct path
            var uri = new UriBuilder(endpoint);
            uri.Path = absolutePath + method;

            // Add parameters in the query if present
            string parToSend;
            if (parameters.Any())
                parToSend = await parameters.Single().ReadAsStringAsync();
            else
                parToSend = string.Empty;

            // Create the string of markets
            var finalParameters = new StringBuilder();
            var splitted = parToSend.Split('&');
            foreach (var s in splitted)
            {
                var m = s.Split('=');

                // If there is a limit parameter, create new FormUrlEncodedContent
                // with that parameter and add it to the Uri Query.
                // Then we can exit the foreach because limit is always at the end.
                if (m[0].Equals("limit"))
                {
                    uri.Query = await new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"limit", m[1]}
                    }).ReadAsStringAsync();
                    break;
                }

                finalParameters.Append(m[0]);
                finalParameters.Append('-');
            }

            // Remove trailing '-'
            finalParameters.Remove(finalParameters.Length - 1, 1);

            // Add to Path not Query
            uri.Path += '/' + finalParameters.ToString();

            return uri.Uri;
        }
    }
}