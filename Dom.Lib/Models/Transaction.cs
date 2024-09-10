using Dom.Lib.Enums;

namespace Dom.Lib.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaydAt { get; set; } = null;
        public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
        public decimal Amount { get; set; }
        public long CategoryId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
