namespace FinAnalyzer.Domain.Entities;

public class UserRoom
{
    public User User { get; set; }

    public int UserId { get; set; } 

    public Room Room { get; set; }

    public int RoomId { get; set; }

    public int Role { get; set; }
}

