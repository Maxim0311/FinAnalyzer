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

        //builder.HasMany(u => u.Rooms)
        //    .WithMany(r => r.Persons)
        //    .UsingEntity<PersonRoom>(
        //        j => j
        //            .HasOne(pt => pt.Room)
        //            .WithMany(t => t.PersonRooms)
        //            .HasForeignKey(pt => pt.RoomId),
        //        j => j
        //            .HasOne(pt => pt.Person)
        //            .WithMany(t => t.PersonRooms)
        //            .HasForeignKey(pt => pt.PersonId),
        //        j =>
        //        {
        //            j.HasKey(t => new { t.PersonId, t.RoomId });
        //            j.ToTable("person_room");
        //            j.Property(p => p.PersonId).HasColumnName("person_id");
        //            j.Property(p => p.RoomId).HasColumnName("room_id");
        //            j.Property(p => p.Role).HasColumnName("role");
        //            j.HasDiscriminator<string>("descriminator");
        //        });

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