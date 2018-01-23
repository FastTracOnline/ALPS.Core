using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ALPS.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}