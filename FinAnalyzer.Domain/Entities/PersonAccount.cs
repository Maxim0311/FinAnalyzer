namespace FinAnalyzer.Domain.Entities;

public class PersonAccount : Account
{
    public Person Person { get; set; }

    public int PersonId { get; set; }
}

