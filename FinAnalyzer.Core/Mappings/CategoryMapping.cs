using AutoMapper;
using FinAnalyzer.Core.Dto.Category;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryResponse>();
    }
}
