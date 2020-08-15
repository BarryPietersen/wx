using Microsoft.AspNetCore.Mvc;
using WxChallenge.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WxChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<User> Get()
        {
            return new User { Name = "Barry Pieterson", Token = "d863ba63-ea8c-46ea-80e6-35303a5d83bd" };
        }
    }
}
