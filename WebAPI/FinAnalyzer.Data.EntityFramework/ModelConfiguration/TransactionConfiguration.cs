using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class TransactionConfiguration : BaseEntityConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.ToTable("transactions");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Amount).HasColumnName("amount");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.TransactionTypeId).HasColumnName("transaction_type_id");
        builder.Property(p => p.DestinationId).HasColumnName("destination_id");
        builder.Property(p => p.SenderId).HasColumnName("sender_id");
        builder.Property(p => p.RoomId).HasColumnName("room_id");
    }
}

