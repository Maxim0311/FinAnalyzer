namespace FinAnalyzer.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<SubCategory> SubCategories { get; set; }

    public Room Room { get; set; }

    public int RoomId { get; set; }
}

