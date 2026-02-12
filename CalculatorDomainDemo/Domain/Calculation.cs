
namespace CalculatorDomainDemo.Domain
{
    public class Calculation
    {
        public int Id { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public OperationType Operation { get; set; }
        public double Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public string UserId { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }

        // Soft delete fields
        public bool IsActive { get; set; } = true;
        public DateTime? DeletedAt { get; set; }
    }
}