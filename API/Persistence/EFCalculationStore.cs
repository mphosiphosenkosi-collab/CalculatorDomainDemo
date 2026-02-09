using CalculatorDomainDemo.Domain;
using CalculatorDomainDemo.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CalculatorDomainDemo.Persistence;
public class EFCalculationStore : ICalculationStore
{
    private readonly CalculatorDbContext _context;

    public EFCalculationStore(CalculatorDbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task SaveAsync(Calculation calculation)
    {
        _context.Calculations.Add(calculation);
        await _context.SaveChangesAsync();
    }
    public async Task<IReadOnlyList<Calculation>> LoadAllAsync()
    {
        return await _context.Calculations.OrderByDescending(c => c.CreatedAt)
        .ToListAsync();
    }
}