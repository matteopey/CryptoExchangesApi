using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi
{
    public interface IDownloadData
    {
        Task<string> Get(string method, Maybe<FormUrlEncodedContent> parameters);
        Task<string> Send(HttpRequestMessage req);
        Task<Uri> CreateUrl(string method, Maybe<FormUrlEncodedContent> parameters);
    }
}
