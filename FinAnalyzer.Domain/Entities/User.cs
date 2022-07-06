namespace FinAnalyzer.Domain.Entities;

public class User : BaseEntity
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Middlename { get; set; }

    public IEnumerable<Room> Rooms { get; set; }
    
    public IEnumerable<PersonAccount> Accounts { get; set; }
    public IEnumerable<UserRoom> UserRooms { get; set; }
}
