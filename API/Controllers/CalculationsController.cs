using CalculatorDomainDemo.Domain;  
using CalculatorDomain.Logic;
using Microsoft.AspNetCore.Mvc;
using CalculatorDomainDemo;


namespace API.controllers
{
    [ApiController]
    [Route("api/calculations")]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculatorService _calculator;

        public CalculationsController(CalculatorService calculator)
        {
            _calculator = calculator;
        }

        [HttpGet] //GET /api/calculations
        public async Task<IActionResult> GetAll()
        {
            var calculations = await _calculator.GetAllAsync(); 
            return Ok(calculations);
        }

        [HttpPost] //POST /api/calculations
        public async Task<IActionResult> Calculate([FromBody]CalculationRequest request)
        {
            var result = await _calculator.CalculateAsync(request);
            return Ok(result);

        }
        
    }

}
