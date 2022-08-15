using FinAnalyzer.Data.EntityFramework.ModelConfiguration;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework;

public class AccountConfiguration : BaseEntityConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        builder.ToTable("account");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Balance).HasColumnName("balance");
        builder.Property(p => p.RoomId).HasColumnName("room_id");
        builder.Property(p => p.AccountTypeId).HasColumnName("account_type_id");
        builder.Property(p => p.PersonId).HasColumnName("person_id");
    }
}