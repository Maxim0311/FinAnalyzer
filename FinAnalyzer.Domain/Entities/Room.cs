using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IEnumerable<Transaction> Transactions { get; set; }

    public IEnumerable<RequestToJoin> RequestsToJoin { get; set; }

    public IEnumerable<User> Users { get; set; }
    public IEnumerable<UserRoom> UserRooms { get; set; }
}

