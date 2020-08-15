using Microsoft.AspNetCore.Mvc;
using WxChallenge.Api.Services;
using WxChallenge.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WxChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyTotalController : ControllerBase
    {
        public ITrolleyService _trolleyService { get; set; }

        public TrolleyTotalController(ITrolleyService trolleyService)
        {
            _trolleyService = trolleyService;
        }

        // POST: api/<TrolleyTotalController>
        [HttpPost]
        public ActionResult<double> Get([FromBody] TrolleyDetail details)
        {
            var lowest = _trolleyService.GetLowestTotal(details).Result;
            return lowest;
        }
    }
}
