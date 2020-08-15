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
            return new User { Name = "Test", Token = "1234-455662-22233333-3333" };
        }
    }
}
