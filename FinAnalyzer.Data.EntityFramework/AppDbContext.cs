using FinAnalyzer.Data.EntityFramework.Extensions;
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
    public DbSet<RequestToJoin> RequestsToJoin { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PersonRoom> PersonRooms { get; set; }
    public DbSet<GlobalRole> GlobalRoles { get; set; }
    public DbSet<RoomRole> RoomRoles { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddModelConfiguration();
        modelBuilder.AddDeletedQueryFilters();
    }
}

