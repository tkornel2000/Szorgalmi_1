using Academy_2023.Data;
using AppLogger;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuveletekController : ControllerBase
    {
        private static Szamparos szamparos = new Szamparos(1, 1);
        // GET: api/<OsszeadController>
        [HttpGet("Osszead")]
        public float Get()
        {
            return szamparos.osszeadas();
        }
        [HttpGet("Kivon")]
        public float Get2()
        {
            return szamparos.kivonas();
        }
        [HttpGet("Szoroz")]
        public float Get3()
        {
            return szamparos.szorzas();
        }
        [HttpGet("Oszt")]
        public float Get4()
        {
            return szamparos.osztas();
        }

        // POST api/<OsszeadController>
        [HttpPost]
        public ActionResult Post([FromBody] Ketszam ketszam)
        {
            szamparos.Setter(ketszam.szam1, ketszam.szam2);
            return ModelState.IsValid?Ok():NoContent();
        }

    }
}
