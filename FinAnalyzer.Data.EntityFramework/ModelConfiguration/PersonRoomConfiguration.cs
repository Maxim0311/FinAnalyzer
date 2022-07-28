using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class PersonRoomConfiguration : IEntityTypeConfiguration<PersonRoom>
{
    public void Configure(EntityTypeBuilder<PersonRoom> builder)
    {
        builder.Property(p => p.PersonId).HasColumnName("person_id");
        builder.Property(p => p.RoomId).HasColumnName("room_id");
        builder.Property(p => p.Role).HasColumnName("role");
    }
}

