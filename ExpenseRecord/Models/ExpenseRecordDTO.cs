using System.ComponentModel.DataAnnotations;

namespace ExpenseRecord.Models
{
    public class ExpenseRecordDTO
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Amount { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
    }
}
