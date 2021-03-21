using Microsoft.EntityFrameworkCore;
using Mortgage.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data
{
    public class MortgagePlannerContext : DbContext
    {
        public DbSet<Prospect> Prospects { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0I4CC7E;Integrated Security=True", b => b.MigrationsAssembly("Mortgage.Data"));
        //}
        public MortgagePlannerContext()
        {
        }

        public MortgagePlannerContext(DbContextOptions<MortgagePlannerContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("MortgagePlannerContext is not configured. Ensure ConnectionString is set.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prospect>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd();

            });
            base.OnModelCreating(modelBuilder);
        }
     }
}
