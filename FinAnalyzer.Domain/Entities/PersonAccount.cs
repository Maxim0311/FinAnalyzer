namespace FinAnalyzer.Domain.Entities;

public class PersonAccount : Account
{
    public User User { get; set; }

    public int UserId { get; set; }
}

