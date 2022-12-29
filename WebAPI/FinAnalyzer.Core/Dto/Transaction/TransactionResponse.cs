using FinAnalyzer.Core.Dto.Account;
using FinAnalyzer.Core.Dto.Category;

namespace FinAnalyzer.Core.Dto.Transaction;

#nullable disable
public class TransactionResponse
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Amount { get; set; }

    public int TransactionTypeId { get; set; }

    public CategoryResponse Category { get; set; }

    public AccountResponse Sender { get; set; }

    public AccountResponse Destination { get; set; }

    public DateTime CreateDate { get; set; }
}

