using FinAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces;

public interface IRequestToJoinRepository
{
    /// <summary>
    /// Подать заявку на вступление в комнату.
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="personId"></param>
    /// <returns></returns>
    Task Apply(int roomId, int personId);

    /// <summary>
    /// Принять заявку на вступление в комнату.
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="personId"></param>
    /// <returns></returns>
    Task Accept(int requestId);

    /// <summary>
    /// Отклонить заявку на вступление в комнату.
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="personId"></param>
    /// <returns></returns>
    Task Reject(int requestId);

    /// <summary>
    /// Получить все заявки на вступление.
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    Task<IEnumerable<RequestToJoin>> GetAllAsync(int roomId);
}
