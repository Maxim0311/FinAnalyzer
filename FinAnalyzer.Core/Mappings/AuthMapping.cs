using AutoMapper;
using FinAnalyzer.Core.Dto.Auth;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class AuthMapping : Profile
{
    public AuthMapping()
    {
        CreateMap<RegistrationRequest, Person>();
    }
}
