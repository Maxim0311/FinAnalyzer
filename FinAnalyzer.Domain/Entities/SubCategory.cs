namespace FinAnalyzer.Domain.Entities;

public class SubCategory : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public Category Category { get; set; }

    public int CategoryId { get; set; }
}
