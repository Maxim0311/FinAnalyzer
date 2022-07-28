using FinAnalyzer.Data.EntityFramework.ModelConfiguration;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework;

#nullable disable

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
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }
}

