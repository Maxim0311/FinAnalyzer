using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class ThirdPartyAccountConfiguration : IEntityTypeConfiguration<ThirdPartyAccount>
{
    public void Configure(EntityTypeBuilder<ThirdPartyAccount> builder)
    {
        builder.HasData(new ThirdPartyAccount
        {
            Id = 1,
            Name = "thirdPartyAcc",
            Balance = 1000,
            RoomId = 1,
        });
    }
}

