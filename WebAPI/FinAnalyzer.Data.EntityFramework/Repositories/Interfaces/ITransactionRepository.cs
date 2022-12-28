using FinAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Data.EntityFramework.Repositories.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByRoomIdAsync(int roomId);
    }
}
