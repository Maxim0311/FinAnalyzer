using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Category;

namespace FinAnalyzer.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<OperationResult<IEnumerable<CategoryResponse>>> GetAllAsync(int roomId);

    Task<OperationResult<int>> CreateAsync(CategoryCreateRequest request);
}

