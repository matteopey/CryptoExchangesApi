using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangesApi
{
    public interface IDownloadData
    {
        Task<string> Get(string method, Maybe<FormUrlEncodedContent> parameters);
    }
}
