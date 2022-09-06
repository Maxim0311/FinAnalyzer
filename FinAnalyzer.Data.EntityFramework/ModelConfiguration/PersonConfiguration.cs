using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class PersonConfiguration : BaseEntityConfiguration<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);

        builder.ToTable("person");
        builder.Property(p => p.Login).HasColumnName("login");
        builder.Property(p => p.Password).HasColumnName("password");
        builder.Property(p => p.Firstname).HasColumnName("firstname");
        builder.Property(p => p.Lastname).HasColumnName("lastname");
        builder.Property(p => p.Middlename).HasColumnName("middlename");
        builder.Property(p => p.GlobalRoleId).HasColumnName("global_role_id");

        builder.HasData(new Person
        {
            Id = 1,
            Login = "admin",
            Password = "admin",
            Firstname = "test",
            Lastname = "test",
            Middlename = "test",
            GlobalRoleId = 1
        });
    }
}