using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class RoomRoleConfiguration : BaseEntityConfiguration<RoomRole>
{
    public override void Configure(EntityTypeBuilder<RoomRole> builder)
    {
        base.Configure(builder);

        builder.ToTable("room_role");

        builder.Property(p => p.Title).HasColumnName("title");

        builder.HasData(new RoomRole[]
        {
            new RoomRole { Id = 1, Title = "Creator" },
            new RoomRole { Id = 2, Title = "Admin" },
            new RoomRole { Id = 3, Title = "Participant" },
        });
    }
}
