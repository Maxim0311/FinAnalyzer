using AutoMapper;
using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Category;
using FinAnalyzer.Core.Services.Interfaces;
using FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;
using FinAnalyzer.Domain.Entities;
using StafferyInternal.StafferyInternal.Common;

namespace FinAnalyzer.Core.Services.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IRoomRepository roomRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<OperationResult<int>> CreateAsync(CategoryCreateRequest categoryDto)
    {
        if (!await _roomRepository.IsExistAsync(categoryDto.RoomId))
            return OperationResult.Fail<int>(OperationCode.EntityWasNotFound, "Указанная комната не найдена");

        var category = _mapper.Map<Category>(categoryDto);
        var createdId = await _categoryRepository.CreateAsync(category);
        return OperationResult.Ok(createdId);
    }

    public async Task<OperationResult<IEnumerable<CategoryResponse>>> GetAllAsync(int roomId)
    {
        var categories = await _categoryRepository.GetByRoomIdAsync(roomId);
        var response = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        return OperationResult.Ok(response);
    }

    public async Task<OperationResult> UpdateAsync(CategoryUpdateRequest categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        if (await _categoryRepository.UpdateAsync(category))
            return OperationResult.OK;

        return OperationResult.Fail(OperationCode.EntityWasNotFound, "Категория не найдена");
    }
    public async Task<OperationResult> DeleteAsync(int id)
    {
        if (await _categoryRepository.DeleteAsync(id))
            return OperationResult.OK;

        return OperationResult.Fail(OperationCode.EntityWasNotFound, "Категория не найдена");
    }
}

