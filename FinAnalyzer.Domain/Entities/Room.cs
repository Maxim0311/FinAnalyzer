namespace FinAnalyzer.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<Transaction> Transactions { get; set; }

    public List<RequestToJoin> RequestsToJoin { get; set; }

    public List<Person> Persons { get; set; }

    public List<PersonRoom> PersonRooms { get; set; }
}

