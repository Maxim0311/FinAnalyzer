using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class RoomConfiguration : BaseEntityConfiguration<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        base.Configure(builder);

        builder.ToTable("room");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
    }
}

