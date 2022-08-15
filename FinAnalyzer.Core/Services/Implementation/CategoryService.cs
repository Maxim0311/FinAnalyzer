using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Category;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

namespace FinAnalyzer.Core.Services.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<OperationResult<IEnumerable<CategoryResponse>>> GetAllAsync(int roomId)
    {
        var categories = await _categoryRepository.GetAllAsync(roomId);

        var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);

        return new OperationResult<IEnumerable<CategoryResponse>>(response);
    }
}

