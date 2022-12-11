using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class TransactionTypeConfiguration : BaseEntityConfiguration<TransactionType>
{
    public override void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        base.Configure(builder);

        builder.ToTable("transaction_type");

        builder.Property(p => p.Title).HasColumnName("title");

        builder.HasData(new TransactionType[]
        {
            new TransactionType
            {
                Id = 1,
                Title = "Income"
            },
            new TransactionType
            {
                Id = 2,
                Title = "Expenditure"
            },
            new TransactionType
            {
                Id = 3,
                Title = "Transfer"
            },
        });
    }
}

