using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi.Tests
{
    public class LocalDownloader : IDownloadData
    {
        private string siteFolder;

        public LocalDownloader(string siteFolder)
        {
            this.siteFolder = siteFolder;
        }

        public Task<Uri> CreateUrl(string method, Maybe<FormUrlEncodedContent> parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Get(string method, Maybe<FormUrlEncodedContent> parameters)
        {
            // Create path
            var file = "../../../" + siteFolder + "/" + method + ".json";

            var stream = File.OpenRead(file);
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public Task<string> Send(HttpRequestMessage req)
        {
            throw new NotImplementedException();
        }
    }
}
