using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker.Models.Entitites
{
    public class BillContext : DbContext
    {
        private static string connString { get; set; }
        public static void Configure(string cString)
        {
            connString = cString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(connString);
            }
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<RecurringBill> RecurringBills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RecurranceFrequency> RecurranceFrequencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bill>(e =>
            {
                e.ToTable("Bills");
                e.HasKey(k => k.Id);

                e.Property(p => p.DisplayName).IsRequired();
            });

            modelBuilder.Entity<RecurranceFrequency>(e =>
            {
                e.ToTable("RecurranceFrequency");
                e.HasKey(k => k.Id);
                e.Property(p => p.NumMonths);
                e.Property(p => p.DisplayName).IsRequired();

            });

            modelBuilder.Entity<RecurringBill>(e =>
            {
                e.ToTable("RecurringBills");
                //e.HasKey(k => k.Id);
                e.HasOne(rb => rb.Bill)
                    .WithMany(b => b.RecurringBills)
                    .HasForeignKey(k => k.Id);
                e.HasOne(rb => rb.RecurranceFrequency)
                    .WithMany(rf => rf.RecurringBills)
                    .HasForeignKey(k => k.RecurranceFrequencyId);
            });

            modelBuilder.Entity<Payment>(e =>
            {
                e.ToTable("Payments");
                e.HasKey(k => k.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.HasOne(p => p.Bill)
                    .WithMany(b => b.Payments)
                    .HasForeignKey(k => k.BillId);
            });
        }
    }
}
