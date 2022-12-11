namespace FinAnalyzer.Common;

public class PaginationRequest
{
    public int Skip { get; set; }
    
    public int Take { get; set; }

    public string? SearchText { get; set; }
}
