using FinAnalyzer.Core.Dto.Person;

namespace FinAnalyzer.Core.Dto.Auth;

#nullable disable
public class AuthResponse
{
    public PersonResponse Person { get; set; }

    public string Token { get; set; }
}

