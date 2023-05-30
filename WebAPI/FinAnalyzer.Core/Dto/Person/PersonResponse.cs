namespace FinAnalyzer.Core.Dto.Person;

public class PersonResponse
{
    public int Id { get; set; }

    public string Login { get; set; } = "";

    public string Firstname { get; set; } = "";

    public string Lastname { get; set; } = "";

    public string Middlename { get; set; } = "";

    public string? RoomRole { get; set; }
}