using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class PersonAccountConfiguration : IEntityTypeConfiguration<PersonAccount>
{
    public void Configure(EntityTypeBuilder<PersonAccount> builder)
    {
        builder.Property(p => p.PersonId).HasColumnName("person_id");

        builder.HasData(new PersonAccount
        {
            Id = 1,
            Name = "personAccount",
            Balance = 1000,
            RoomId = 1,
            PersonId = 1,
        });
    }
}