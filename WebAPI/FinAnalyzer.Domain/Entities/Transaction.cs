namespace FinAnalyzer.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }
        public int TransactionTypeId { get; set; }

        public Category? Category { get; set; }
        public int? CategoryId { get; set; }

        public Account Destination { get; set; }
        public int DestinationId { get; set; }

        public Account Sender { get; set; }
        public int SenderId { get; set; }
        
        public Room? Room { get; set; }
        public int? RoomId { get; set; }
    }
}