using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class CategoryConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("category");
        builder.Property(p => p.IsExpenditure).HasColumnName("is_expenditure");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.RoomId).HasColumnName("room_id");

        builder.HasData(new Category
        {
            Id = 1,
            Name = "testCategory",
            Description = "description",
            RoomId = 1,
        });
    }
}

