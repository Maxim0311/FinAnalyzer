namespace FinAnalyzer.Core.Dto.Account;

#nullable disable
public class AccountResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Balance { get; set; }

    public AccountTypeResponse AccountType { get; set; }

    public int RoomId { get; set; }

    public string PersonName { get; set; }
}

public class AccountTypeResponse
{
    public int Id { get; set; }

    public string Title { get; set; }
}

//public class AccountPersonResponse
//{
//    public int Id { get; set; }


//}