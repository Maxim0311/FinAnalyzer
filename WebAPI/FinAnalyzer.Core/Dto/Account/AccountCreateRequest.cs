namespace FinAnalyzer.Core.Dto.Account;

#nullable disable
public class AccountCreateRequest
{
    public string Name { get; set; }

    public int RoomId { get; set; }

    public int AccountTypeId { get; set; }

    public int? PersonId { get; set; }
}

