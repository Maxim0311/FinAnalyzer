using AutoMapper;
using FinAnalyzer.Core.Dto.Transaction;
using FinAnalyzer.Domain.Entities;

namespace FinAnalyzer.Core.Mappings;

public class TransactionMapping : Profile
{
    public TransactionMapping()
    {
        CreateMap<Transaction, TransactionResponse>();
    }
}

