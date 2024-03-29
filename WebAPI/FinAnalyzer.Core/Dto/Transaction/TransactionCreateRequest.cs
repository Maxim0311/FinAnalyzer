﻿namespace FinAnalyzer.Core.Dto.Transaction;

#nullable disable
public class TransactionCreateRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Amount { get; set; }

    public int? CategoryId { get; set; }

    public int RoomId { get; set; }
}

