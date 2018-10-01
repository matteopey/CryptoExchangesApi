using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi
{
    /// <summary>
    /// Download data from the APIs.
    /// </summary>
	public class DownloadData : IDownloadData
	{
		int requestsNumber = 0;
		HttpClient client = new HttpClient();

        private readonly string endpoint;
	    private readonly string absolutePath;

	    public DownloadData(string endpoint, string absolutePath)
	    {
	        this.endpoint = endpoint;
	        this.absolutePath = absolutePath;
	    }

	    /// <summary>
        /// Get the data from the provided API.
        /// </summary>
        /// <param name="method">API method name</param>
        /// <param name="parameters">Parameters for the API</param>
        /// <returns></returns>
        public async Task<string> Get(string method, Maybe<FormUrlEncodedContent> parameters)
        {
            var uri = await CreateUrl(method, parameters);
            return await MakeCall(uri);
        }

        /// <summary>
        /// Actually make the HTTP GET call.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
	    private async Task<string> MakeCall(Uri uri)
	    {
	        try
	        {
	            HttpClientManagement();
	            requestsNumber++;
	            var res = await client.GetAsync(uri);

	            if (res.StatusCode == HttpStatusCode.TooManyRequests)
	                throw new HttpRequestException("Requests limit exceeded");

	            if (!res.IsSuccessStatusCode)
	                throw new HttpRequestException($"Error in response, code: {res.StatusCode}");

	            return await res.Content.ReadAsStringAsync();
	        }
	        catch (HttpRequestException e)
	        {
	            throw e;
	        }
        }

        /// <summary>
        /// Create URL to use.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
	    private async Task<Uri> CreateUrl(string method, Maybe<FormUrlEncodedContent> parameters)
	    {
            // Create uri with correct path
	        var uri = new UriBuilder(endpoint);
	        uri.Path = absolutePath + method;

            // Add parameters in the query if present
            string par;
	        if (parameters.Any())
	            par = await parameters.Single().ReadAsStringAsync();
	        else
	            par = string.Empty;
	        uri.Query = par;

	        return uri.Uri;
	    }

        /// <summary>
        /// Manage creation and disposing of the HTTP client.
        /// </summary>
	    private void HttpClientManagement()
	    {
	        if (requestsNumber == 20)
	        {
	            client.Dispose();

	            requestsNumber = 0;
	            client = new HttpClient();
	        }
	    }
    }    
}
