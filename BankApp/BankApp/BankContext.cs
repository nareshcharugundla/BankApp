using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public BankContext() 
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BankDatabase;Integrated Security=True;Connect Timeout=30"); //using @ to ignore the escape character
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>(entity =>
            {
                entity 
                  .HasKey(e => e.AccountNumber)
                  .HasName("PK_Accounts");

                entity.Property(e => e.AccountNumber)
                  .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailAddress)
                  .IsRequired()
                  .HasMaxLength(50);

                entity.Property(e => e.AccountType)
                  .IsRequired();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(e => e.TransactionID)
                      .HasName("PK_Transactions");

                entity.Property(e => e.TransactionID)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                      .IsRequired();

                entity.HasOne(e => e.Account)
                      .WithMany()
                      .HasForeignKey(e => e.AccountNumber);
            });
            
        }
    }
}
