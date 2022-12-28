using AutoMapper;
using FinAnalyzer.Core.Dto.Account;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class AccountMapping : Profile
{
    public AccountMapping()
    {
        CreateMap<Account, AccountResponse>()
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person!.Login));
        CreateMap<AccountType, AccountTypeResponse>();
        CreateMap<AccountCreateRequest, Account>();
    }
}

