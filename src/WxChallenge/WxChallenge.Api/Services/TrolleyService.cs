using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WxChallenge.Core.Models;

namespace WxChallenge.Api.Services
{
    public class TrolleyService : ITrolleyService
    {
        private readonly string _wxBaseUrl = "";
        private readonly string _wxClientTokenParam = "";
        private readonly string _wxTrolleyCalculatorRoute = "";

        public TrolleyService(IConfiguration config)
        {
            _wxBaseUrl = config.GetValue<string>("WxBaseUrl");
            _wxClientTokenParam = config.GetValue<string>("WxClientTokenParam");
            _wxTrolleyCalculatorRoute = config.GetValue<string>("WxTrolleyCalulatorRoute");
        }

        public async Task<double> GetLowestTotal(TrolleyDetail details)
        {
            var shopperHistory = 0d;

            using (HttpClient http = new HttpClient())
            {
                var wxEndpoint = $"{_wxBaseUrl}/{_wxTrolleyCalculatorRoute}?{_wxClientTokenParam}";
                var requestBody = JsonConvert.SerializeObject(details);
                var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var httpResponse = await http.PostAsync(wxEndpoint, httpContent);

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                // check if response status ok etc

                shopperHistory = JsonConvert.DeserializeObject<double>(result);
            }

            return shopperHistory;
        }
    }
}
