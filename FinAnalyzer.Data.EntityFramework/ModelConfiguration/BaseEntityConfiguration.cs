using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class BaseEntityConfiguration<TEnity> : IEntityTypeConfiguration<TEnity> where TEnity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEnity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreateDate)
            .HasColumnName("create_date")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdateDate)
            .HasColumnName("update_date")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.DeleteDate).HasColumnName("delete_date");
    }
}