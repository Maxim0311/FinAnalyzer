namespace FinAnalyzer.Domain.Entities;

public class Account : BaseEntity
{
    public string Name { get; set; }

    public decimal Balance { get; set; }

    public Room Room { get; set; }

    public int RoomId { get; set; }
}
