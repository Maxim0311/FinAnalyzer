using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class PersonRoomConfiguration : IEntityTypeConfiguration<PersonRoom>
{
    public void Configure(EntityTypeBuilder<PersonRoom> builder)
    {
        builder.HasKey(p => new { p.PersonId, p.RoomId });

        builder.ToTable("person_room");
        builder.Property(p => p.PersonId).HasColumnName("person_id");
        builder.Property(p => p.RoomId).HasColumnName("room_id");
        builder.Property(p => p.RoomRoleId).HasColumnName("room_role_id");
    }
}

