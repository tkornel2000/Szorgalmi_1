using Academy_2023.Data;
using AppLogger;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        // POST api/<OsszeadController>
        [HttpPost]
        public ActionResult Post([FromBody] Szamparos szp)
        {
            var result = szp.calculate();
            if (result == null) { return BadRequest(); }
            else { return Ok(szp.calculate()); }
        }

    }
}
