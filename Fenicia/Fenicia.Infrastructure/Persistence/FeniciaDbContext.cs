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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public FeniciaDbContext(DbContextOptions<FeniciaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property(a => a.Street).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.Number).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.Floor).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.Door).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.ZipCode).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>()
                .HasOne<City>(a => a.CityAddress)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<City>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<City>()
                .HasOne<Country>(c => c.CountryCity)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.idCountry);

            modelBuilder.Entity<Customer>().Property(a => a.TradeName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.FiscalName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.Nif).IsRequired().HasMaxLength(9);
            modelBuilder.Entity<Customer>().Property(a => a.Phone).IsRequired();
            modelBuilder.Entity<Customer>().Property(a => a.Web).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.Email).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.Fax).IsRequired();
            modelBuilder.Entity<Customer>()
                .HasOne<Address>(c => c.FiscalAddress)
                .WithOne(a => a.FiscalAddressCustomer)
                .HasForeignKey<Customer>(x => x.FiscalAddressId);

            modelBuilder.Entity<DeliveryAddress>()
                .HasOne<Customer>(d => d.Customer)
                .WithMany(c => c.DeliveryAddresses)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>().Property(e => e.Job).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnType("decimal(8,2)").IsRequired();

            modelBuilder.Entity<Menu>().Property(e => e.Name).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<Menu>().Property(e => e.Location).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Menu>().Property(e => e.ParentId).IsRequired();
            modelBuilder.Entity<Menu>()
                .HasMany<Person>(m => m.Persons)
                .WithOne(p => p.Menu)
                .HasForeignKey(p => p.MenuId);

            modelBuilder.Entity<Order>().Property(e => e.NumberItems).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Priority).HasColumnType(.IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Iva).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.TotalPrice).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne<DeliveryAddress>(o => o.DeliveryAddress)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DeliveryAddressId);
            modelBuilder.Entity<Order>()
                .HasOne<Customer>(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Order>()
                .HasOne<Employee>(o => o.Employee)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<OrderItem>().Property(e => e.Discount).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(oi => oi.Product)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Product>().Property(e => e.Price).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Product>().Property(e => e.Iva).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Product>()
                .HasOne<Category>(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Customer>().ToTable("Customer");

        }
    }
}
