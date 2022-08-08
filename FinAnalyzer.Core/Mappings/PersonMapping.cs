using AutoMapper;
using FinAnalyzer.Core.Dto.Person;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class PersonMapping : Profile
{
    public PersonMapping()
    {
        CreateMap<Person, PersonResponse>();
    }
}

