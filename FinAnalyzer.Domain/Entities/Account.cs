namespace FinAnalyzer.Domain.Entities;

public class Account : BaseEntity
{
    public string Name { get; set; }

    public decimal Balance { get; set; }

    public AccountType AccountType { get; set; }
    public int AccountTypeId { get; set; }

    public Room Room { get; set; }
    public int RoomId { get; set; }

    public Person? Person { get; set; }
    public int? PersonId { get; set; }
}
