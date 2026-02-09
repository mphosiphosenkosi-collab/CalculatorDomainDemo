using CalculatorDomain.Logic;

using CalculatorDomainDemo.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;

[ApiController]
[Route("api/history")]
[Authorize(Roles ="Admin")]
public class HistoryController : ControllerBase
{
    private readonly CalculatorService _calculator;
    private readonly EFCalculationStore _context; 

    public HistoryController(CalculatorService calculator, EFCalculationStore calculatorDbContext)
    {
        _calculator = calculator;
        _context = calculatorDbContext; 
    }

    [HttpGet]
    public async Task<IActionResult> GetHistory()
    {
        var history = await _context.LoadAllAsync();

        var response = history.Select(c => new CalculationHistoryItemDto
        {
            Left = c.Left,
            Right = c.Right,
            Operation = c.Operation.ToString(),
            Result = c.Result
        });

        return Ok(response);
    }
}
