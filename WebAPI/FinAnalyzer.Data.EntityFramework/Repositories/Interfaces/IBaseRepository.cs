using FinAnalyzer.Common;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

/// <summary>
/// Интерфейс базового репозитория. Содержит минимальный набор методов работы с БД
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Существует ли сущность в БД с данным идентификатором
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> IsExistAsync(int id);

    /// <summary>
    /// Получить сущность по индентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(int id);

    /// <summary>
    /// Добавить новую сущность в БД
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<int> CreateAsync(TEntity entity);

    /// <summary>
    /// Удалить сущность из БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// Получить все экземляры сущности из БД
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// Получить все экзампляры сущности из БД с постраничным выводом. Для логики с поиском необходимо переопределить метод
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<PaginationResponse<TEntity>> GetAllAsync(PaginationRequest pagination);
}

