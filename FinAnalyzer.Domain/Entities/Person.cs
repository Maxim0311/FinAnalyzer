namespace FinAnalyzer.Domain.Entities;

public class Person : BaseEntity
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Middlename { get; set; }

    //public List<Room> Rooms { get; set; }

    public List<PersonRoom> PersonRooms { get; set; } = new List<PersonRoom>();

    public List<PersonAccount> Accounts { get; set; }
}
