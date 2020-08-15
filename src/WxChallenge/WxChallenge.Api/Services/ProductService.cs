using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WxChallenge.Core.Models;

namespace WxChallenge.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly string _wxBaseUrl = "";
        private readonly string _wxProductRoute = "";
        private readonly string _wxClientTokenParam = "";

        public ProductService(IConfiguration config)
        {
            _wxBaseUrl = config.GetValue<string>("WxBaseUrl");
            _wxProductRoute = config.GetValue<string>("WxProductRoute");
            _wxClientTokenParam = config.GetValue<string>("WxClientTokenParam");
        }

        // for performance reasons we could consider applying a cache to this service, and periodically refresh the product data

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> products = Enumerable.Empty<Product>();

            using (HttpClient http = new HttpClient())
            {
                var responseBody = await http.GetStringAsync($"{_wxBaseUrl}/{_wxProductRoute}?{_wxClientTokenParam}");

                // check if response status ok etc

                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseBody);
            }

            return products;
        }
    }
}
