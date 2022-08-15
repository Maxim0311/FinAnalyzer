namespace FinAnalyzer.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<Account> Accounts { get; set; } = new List<Account>();

    public List<Transaction> Transactions { get; set; }

    public List<Category> Categories { get; set; }

    public List<RequestToJoin> RequestsToJoin { get; set; }

    //public List<Person> Persons { get; set; } = new List<Person>();

    public List<PersonRoom> PersonRooms { get; set; } = new List<PersonRoom>();
}

