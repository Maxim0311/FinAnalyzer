using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Domain.Entities;

/// <summary>
/// Статус заявки на вступление в комнату.
/// </summary>
public enum RequestToJoinStatus
{
    /// <summary>
    /// Новая.
    /// </summary>
    New,

    /// <summary>
    /// Одобренная.
    /// </summary>
    Accepted,

    /// <summary>
    /// Отклонена.
    /// </summary>
    Rejected
}
