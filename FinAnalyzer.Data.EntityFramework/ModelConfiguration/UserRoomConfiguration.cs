using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class UserRoomConfiguration : IEntityTypeConfiguration<UserRoom>
{
    public void Configure(EntityTypeBuilder<UserRoom> builder)
    {
        
    }
}

