using AutoMapper;
using FinAnalyzer.Core.Dto.Category;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryResponse>()
            .ForMember(dest => dest.IconColor, opt => opt.MapFrom(src => src.Color));
        CreateMap<CategoryUpdateRequest, Category>()
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.IconColor));
        CreateMap<CategoryCreateRequest, Category>()
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.IconColor));
    }
}
