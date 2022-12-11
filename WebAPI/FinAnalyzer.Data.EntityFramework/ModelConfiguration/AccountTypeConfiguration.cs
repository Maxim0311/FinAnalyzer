using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class AccountTypeConfiguration : BaseEntityConfiguration<AccountType>
{
    public override void Configure(EntityTypeBuilder<AccountType> builder)
    {
        base.Configure(builder);

        builder.ToTable("account_type");

        builder.Property(p => p.Title).HasColumnName("title");

        builder.HasData(new AccountType[] {
            new AccountType
            {
                Id = 1,
                Title = "Person"
            },
            new AccountType
            {
                Id = 2,
                Title = "Room"
            },
            new AccountType
            {
                Id = 3,
                Title = "ThirdParty"
            },
        });
    }
}

