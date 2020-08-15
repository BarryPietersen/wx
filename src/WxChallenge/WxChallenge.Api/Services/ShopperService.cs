using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WxChallenge.Core.Models;

namespace WxChallenge.Api.Services
{
    public class ShopperService : IShopperService
    {
        private readonly string _wxBaseUrl = "";
        private readonly string _wxClientTokenParam = "";
        private readonly string _wxShopperHistoryRoute = "";

        public ShopperService(IConfiguration config)
        {
            _wxBaseUrl = config.GetValue<string>("WxBaseUrl");
            _wxClientTokenParam = config.GetValue<string>("WxClientTokenParam");
            _wxShopperHistoryRoute = config.GetValue<string>("WxShopperHistoryRoute");
        }

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistory()
        {
            var shopperHistory = Enumerable.Empty<ShopperHistory>();

            using (HttpClient http = new HttpClient())
            {
                var responseBody = await http.GetStringAsync($"{_wxBaseUrl}/{_wxShopperHistoryRoute}?{_wxClientTokenParam}");

                // check if response status ok etc

                shopperHistory = JsonConvert.DeserializeObject<IEnumerable<ShopperHistory>>(responseBody);
            }

            return shopperHistory;
        }

        // shopper cart etc..
    }
}
