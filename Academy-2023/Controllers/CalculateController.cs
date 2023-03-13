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
        [HttpGet]
        public double Calculation([FromQuery] double a, [FromQuery] double b, [FromQuery] string operation)
        {
            double result;
            Calculator calc = new Calculator();
            switch (operation)
            {
                case "+":
                    result = calc.Add(a, b);
                    break;
                case "-":
                    result = calc.Sub(a, b);
                    break;
                case "*":
                    result = calc.Multiply(a, b);
                    break;
                case "/":
                    result = calc.Div(a, b);
                    break;
                default:
                    throw new Exception("operation was not found");
            }
            return result;
            
        }

    }
}
