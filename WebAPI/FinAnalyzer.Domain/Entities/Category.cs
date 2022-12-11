namespace FinAnalyzer.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// true, если категория расходная
    /// </summary>
    public bool IsExpenditure { get; set; }

    public string IconAuthor { get; set; }

    public string IconName { get; set; }

    public string Color { get; set; }

    public Room Room { get; set; }
    public int RoomId { get; set; }
}

