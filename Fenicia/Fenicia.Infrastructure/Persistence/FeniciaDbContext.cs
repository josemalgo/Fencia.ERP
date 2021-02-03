using Fenicia.Application.Common.Interfaces;
using Fenicia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fenicia.Infrastructure.Persistence
{
    public class FeniciaDbContext : DbContext, IFeniciaDbContext
    {
        public FeniciaDbContext(DbContextOptions<FeniciaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasMany<Person>(m => m.Persons)
                .WithOne(p => p.Menu)
                .HasForeignKey(p => p.MenuId);
        }
    }
}
