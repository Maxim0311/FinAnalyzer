using FinAnalyzer.Data.EntityFramework.ModelConfiguration;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework;

public class AppDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<PersonAccount> PersonAccounts { get; set; }
    public DbSet<RoomAccount> RoomAccounts { get; set; }
    public DbSet<ThirdPartyAccount> ThirdPartyAccounts { get; set; }
    public DbSet<RequestToJoin> RequestsToJoin { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new PersonAccountConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new RequestToJoinConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        //modelBuilder.Entity<User>()
        //    .HasMany(u => u.Rooms)
        //    .WithMany(r => r.Users)
        //    .UsingEntity<UserRoom>(
        //        j => j
        //            .HasOne(pt => pt.Room)
        //            .WithMany(t => t.UserRooms)
        //            .HasForeignKey(pt => pt.RoomId),
        //        j => j
        //            .HasOne(pt => pt.User)
        //            .WithMany(t => t.UserRooms)
        //            .HasForeignKey(pt => pt.UserId),
        //        j =>
        //        {
        //            j.HasKey(t => new { t.UserId, t.RoomId });
        //            j.ToTable("user_room");
        //        });
    }
}

