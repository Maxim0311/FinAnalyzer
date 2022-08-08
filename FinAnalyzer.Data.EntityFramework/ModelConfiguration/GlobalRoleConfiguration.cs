using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class GlobalRoleConfiguration : BaseEntityConfiguration<GlobalRole>
{
    public override void Configure(EntityTypeBuilder<GlobalRole> builder)
    {
        base.Configure(builder);

        builder.ToTable("global_role");

        builder.Property(p => p.Title).HasColumnName("title");

        builder.HasData(new GlobalRole[]
        {
            new GlobalRole { Id = 1, Title = "Admin" },
            new GlobalRole { Id = 2, Title = "User" },
        });
    }
}

