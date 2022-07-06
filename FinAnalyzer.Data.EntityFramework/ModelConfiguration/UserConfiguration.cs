using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");
        builder.Property(p => p.Login).HasColumnName("login");
        builder.Property(p => p.Password).HasColumnName("password");
        builder.Property(p => p.Firstname).HasColumnName("firstname");
        builder.Property(p => p.Lastname).HasColumnName("lastname");
        builder.Property(p => p.Middlename).HasColumnName("middlename");

        builder.HasMany(u => u.Rooms)
            .WithMany(r => r.Users)
            .UsingEntity<UserRoom>(
                j => j
                    .HasOne(pt => pt.Room)
                    .WithMany(t => t.UserRooms)
                    .HasForeignKey(pt => pt.RoomId),
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.UserRooms)
                    .HasForeignKey(pt => pt.UserId),
                j =>
                {
                    j.HasKey(t => new { t.UserId, t.RoomId });
                    j.ToTable("user_room");
                    j.Property(p => p.UserId).HasColumnName("user_id");
                    j.Property(p => p.RoomId).HasColumnName("room_id");
                    j.Property(p => p.Role).HasColumnName("role");
                    j.HasDiscriminator<string>("descriminator");
                });

        builder.HasData(new User
        {
            Id = 1,
            Login = "admin",
            Password = "admin",
            Firstname = "test",
            Lastname = "test",
            Middlename = "test",
        });
    }
}