using EFCoreTest1.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest1
{
    public class TestContext : DbContext
    {
        public DbSet<Afspraak> Afspraken { get; set; }

        public DbSet<Taak> Taken { get; set; }
        public DbSet<StatusHistorie> StatusHistories { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afspraak>()
                .OwnsOne(a => a.Adres)
                .OwnsOne(o => o.Huisnummer);

            modelBuilder.Entity<Taak>()
                .HasMany<StatusHistorie>()
                .WithOne(s => s.Taak);

        }
    }
}
 