using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetJuryList()
        {
            return Ok();
        }
    }
}
