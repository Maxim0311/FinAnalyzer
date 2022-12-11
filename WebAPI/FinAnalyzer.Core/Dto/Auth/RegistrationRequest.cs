namespace FinAnalyzer.Core.Dto.Auth;

#nullable disable

public class RegistrationRequest
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Middlename { get; set; }
}

