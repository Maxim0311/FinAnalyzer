using FinAnalyzer.Data.EntityFramework.ModelConfiguration;
using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinAnalyzer.Data.EntityFramework.Extensions;

public static class ModelBuilderExtension
{
    public static ModelBuilder AddModelConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new RequestToJoinConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new PersonRoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomRoleConfiguration());
        modelBuilder.ApplyConfiguration(new GlobalRoleConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());

        return modelBuilder;
    }

    public static ModelBuilder AddDeletedQueryFilters(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<Category>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<GlobalRole>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<Person>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<RequestToJoin>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<Room>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<RoomRole>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<Transaction>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<PersonRoom>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<TransactionType>().HasQueryFilter(e => e.DeleteDate == null);
        modelBuilder.Entity<AccountType>().HasQueryFilter(e => e.DeleteDate == null);

        return modelBuilder;
    }
}

