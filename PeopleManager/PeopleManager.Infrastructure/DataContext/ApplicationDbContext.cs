using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PeopleManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-59IHUTG\\SQLEXPRESS;Database=PersonManagementDB;Trusted_Connection=True;Trust Server Certificate=true");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuration des relations et des contraintes
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Jobs)
                .WithOne(j => j.Person)
                .HasForeignKey(j => j.PersonId);

            modelBuilder.Entity<Job>()
                .HasKey(j => j.Id);

            modelBuilder.Entity<Job>()
                .Property(j => j.EndDate)
                .IsRequired(false);
        }
    }
}
