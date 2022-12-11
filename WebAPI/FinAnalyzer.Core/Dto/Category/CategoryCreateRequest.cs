namespace FinAnalyzer.Core.Dto.Category;

#nullable disable
public class CategoryCreateRequest
{
    public int RoomId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsExpenditure { get; set; }

    public string IconAuthor { get; set; }

    public string IconName { get; set; }

    public string Color { get; set; }
}