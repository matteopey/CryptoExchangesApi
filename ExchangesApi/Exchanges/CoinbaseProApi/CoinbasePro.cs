using ExchangesApi.Exchanges.CoinbaseProApi.ApiCalls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangesApi.Exchanges.CoinbaseProApi
{
    public class CoinbasePro
    {
        private readonly PublicMethods _publicApi;

        public CoinbasePro(Maybe<IDownloadData> downloader)
        {
            // If a downloader is not provided, create the default
            if (!downloader.Any())
            {
                downloader = new Maybe<IDownloadData>(
                    new DownloadData(Constants.Endpoint, Constants.AbsolutePath)
                );
            }

            _publicApi = new PublicMethods(downloader.Single());
        }

        public async Task<Currencies> GetCurrenciesAsync()
        {
            try
            {
                return await _publicApi.GetCurrencies();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Products> GetProductsAsync()
        {
            try
            {
                return await _publicApi.GetProducts();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ProductTicker> GetProductTickerAsync(string productId)
        {
            try
            {
                return await _publicApi.GetProductTicker(productId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
