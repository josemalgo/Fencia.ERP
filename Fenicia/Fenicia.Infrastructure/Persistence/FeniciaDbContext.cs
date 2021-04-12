using Fenicia.Application.Common.Interfaces;
using Fenicia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Infrastructure.Persistence
{
    public class FeniciaDbContext : DbContext, IFeniciaDbContext
    {
        private IDbContextTransaction _transaction;

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
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
            modelBuilder.Entity<Address>().Property(a => a.Description).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Address>().Property(a => a.ZipCode).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Address>()
                .HasOne(e => e.Person)
                .WithMany(a => a.Addresses)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Address>()
                .HasOne(e => e.Customer)
                .WithMany(a => a.Addresses)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasData(                
                new Country { Id = Guid.NewGuid(), Name = "Afganistán" },
                new Country { Id = Guid.NewGuid(), Name = "Albania"},
                new Country { Id = Guid.NewGuid(), Name = "Alemania"},
                new Country { Id = Guid.NewGuid(), Name = "Andorra"},
                new Country { Id = Guid.NewGuid(), Name = "Angola" },
                new Country { Id = Guid.NewGuid(), Name = "Antigua y Barbuda" },
                new Country { Id = Guid.NewGuid(), Name = "Arabia Saudita" },
                new Country { Id = Guid.NewGuid(), Name = "Argelia" },
                new Country { Id = Guid.NewGuid(), Name = "Argentina" },
                new Country { Id = Guid.NewGuid(), Name = "Armenia" },
                new Country { Id = Guid.NewGuid(), Name = "Australia" },
                new Country { Id = Guid.NewGuid(), Name = "Austria" },
                new Country { Id = Guid.NewGuid(), Name = "Azerbaiyán" },
                new Country { Id = Guid.NewGuid(), Name = "Bahamas" },
                new Country { Id = Guid.NewGuid(), Name = "Bahréin" },
                new Country { Id = Guid.NewGuid(), Name = "Bangladés" },
                new Country { Id = Guid.NewGuid(), Name = "Barbados" },
                new Country { Id = Guid.NewGuid(), Name = "Bielorrusia" },
                new Country { Id = Guid.NewGuid(), Name = "Bélgica" },
                new Country { Id = Guid.NewGuid(), Name = "Belice" },
                new Country { Id = Guid.NewGuid(), Name = "Benín" },
                new Country { Id = Guid.NewGuid(), Name = "Bután" },
                new Country { Id = Guid.NewGuid(), Name = "Bolivia" },
                new Country { Id = Guid.NewGuid(), Name = "Bosnia-Herzegovina" },
                new Country { Id = Guid.NewGuid(), Name = "Botsuana" },
                new Country { Id = Guid.NewGuid(), Name = "Brasil" },
                new Country { Id = Guid.NewGuid(), Name = "Brunéi" },
                new Country { Id = Guid.NewGuid(), Name = "Bulgaria" },
                new Country { Id = Guid.NewGuid(), Name = "Burkina Faso" },
                new Country { Id = Guid.NewGuid(), Name = "Burundi" },
                new Country { Id = Guid.NewGuid(), Name = "Cabo Verde" },
                new Country { Id = Guid.NewGuid(), Name = "Camboya" },
                new Country { Id = Guid.NewGuid(), Name = "Camerún" },
                new Country { Id = Guid.NewGuid(), Name = "Canadá" },
                new Country { Id = Guid.NewGuid(), Name = "Chad" },
                new Country { Id = Guid.NewGuid(), Name = "República Checa" },
                new Country { Id = Guid.NewGuid(), Name = "Chequia" },
                new Country { Id = Guid.NewGuid(), Name = "Chile" },
                new Country { Id = Guid.NewGuid(), Name = "China" },
                new Country { Id = Guid.NewGuid(), Name = "Chipre" },
                new Country { Id = Guid.NewGuid(), Name = "Colombia" },
                new Country { Id = Guid.NewGuid(), Name = "Comoras" },
                new Country { Id = Guid.NewGuid(), Name = "Congo" },
                new Country { Id = Guid.NewGuid(), Name = "República Democrática del Congo" },
                new Country { Id = Guid.NewGuid(), Name = "Corea del Norte" },
                new Country { Id = Guid.NewGuid(), Name = "Corea del Sur" },
                new Country { Id = Guid.NewGuid(), Name = "Costa Rica" },
                new Country { Id = Guid.NewGuid(), Name = "Costa de Marfil" },
                new Country { Id = Guid.NewGuid(), Name = "Croacia" },
                new Country { Id = Guid.NewGuid(), Name = "Cuba" },
                new Country { Id = Guid.NewGuid(), Name = "Dinamarca" },
                new Country { Id = Guid.NewGuid(), Name = "Yibuti" },
                new Country { Id = Guid.NewGuid(), Name = "Dominica" },
                new Country { Id = Guid.NewGuid(), Name = "Ecuador" },
                new Country { Id = Guid.NewGuid(), Name = "Egipto" },
                new Country { Id = Guid.NewGuid(), Name = "El Salvador" },
                new Country { Id = Guid.NewGuid(), Name = "Emiratos Árabes Unidos" },
                new Country { Id = Guid.NewGuid(), Name = "Eritrea" },
                new Country { Id = Guid.NewGuid(), Name = "Eslovaquia" },
                new Country { Id = Guid.NewGuid(), Name = "Eslovenia" },
                new Country { Id = Guid.NewGuid(), Name = "España" },
                new Country { Id = Guid.NewGuid(), Name = "Estados Unidos" },
                new Country { Id = Guid.NewGuid(), Name = "Estonia" },
                new Country { Id = Guid.NewGuid(), Name = "Etiopía" },
                new Country { Id = Guid.NewGuid(), Name = "Fiyi" },
                new Country { Id = Guid.NewGuid(), Name = "Filipinas" },
                new Country { Id = Guid.NewGuid(), Name = "Finlandia" },
                new Country { Id = Guid.NewGuid(), Name = "Francia" },
                new Country { Id = Guid.NewGuid(), Name = "Gabón" },
                new Country { Id = Guid.NewGuid(), Name = "Gambia" },
                new Country { Id = Guid.NewGuid(), Name = "Georgia" },
                new Country { Id = Guid.NewGuid(), Name = "Ghana" },
                new Country { Id = Guid.NewGuid(), Name = "Granada" },
                new Country { Id = Guid.NewGuid(), Name = "Grecia" },
                new Country { Id = Guid.NewGuid(), Name = "Guatemala" },
                new Country { Id = Guid.NewGuid(), Name = "Guinea" },
                new Country { Id = Guid.NewGuid(), Name = "Guinea-Bissau" },
                new Country { Id = Guid.NewGuid(), Name = "Guinea Ecuatorial" },
                new Country { Id = Guid.NewGuid(), Name = "Guyana" },
                new Country { Id = Guid.NewGuid(), Name = "Haití" },
                new Country { Id = Guid.NewGuid(), Name = "Honduras" },
                new Country { Id = Guid.NewGuid(), Name = "Hungría" },
                new Country { Id = Guid.NewGuid(), Name = "India" },
                new Country { Id = Guid.NewGuid(), Name = "Indonesia" },
                new Country { Id = Guid.NewGuid(), Name = "Irán" },
                new Country { Id = Guid.NewGuid(), Name = "Iraq" },
                new Country { Id = Guid.NewGuid(), Name = "Irlanda" },
                new Country { Id = Guid.NewGuid(), Name = "Islandia" },
                new Country { Id = Guid.NewGuid(), Name = "Israel" },
                new Country { Id = Guid.NewGuid(), Name = "Italia" },
                new Country { Id = Guid.NewGuid(), Name = "Jamaica" },
                new Country { Id = Guid.NewGuid(), Name = "Japón" },
                new Country { Id = Guid.NewGuid(), Name = "Jordania" },
                new Country { Id = Guid.NewGuid(), Name = "Kazajistán" },
                new Country { Id = Guid.NewGuid(), Name = "Kenia" },
                new Country { Id = Guid.NewGuid(), Name = "Kirguistán" },
                new Country { Id = Guid.NewGuid(), Name = "Kiribati" },
                new Country { Id = Guid.NewGuid(), Name = "Kuwait" },
                new Country { Id = Guid.NewGuid(), Name = "Laos" },
                new Country { Id = Guid.NewGuid(), Name = "Lesoto" },
                new Country { Id = Guid.NewGuid(), Name = "Letonia" },
                new Country { Id = Guid.NewGuid(), Name = "Líbano" },
                new Country { Id = Guid.NewGuid(), Name = "Liberia" },
                new Country { Id = Guid.NewGuid(), Name = "Libia" },
                new Country { Id = Guid.NewGuid(), Name = "Liechtenstein" },
                new Country { Id = Guid.NewGuid(), Name = "Lituania" },
                new Country { Id = Guid.NewGuid(), Name = "Luxemburgo" },
                new Country { Id = Guid.NewGuid(), Name = "Macedonia" },
                new Country { Id = Guid.NewGuid(), Name = "Madagascar" },
                new Country { Id = Guid.NewGuid(), Name = "Malasia" },
                new Country { Id = Guid.NewGuid(), Name = "Malaui" },
                new Country { Id = Guid.NewGuid(), Name = "Maldivas" },
                new Country { Id = Guid.NewGuid(), Name = "Mali / Malí" },
                new Country { Id = Guid.NewGuid(), Name = "Malta" },
                new Country { Id = Guid.NewGuid(), Name = "Marruecos" },
                new Country { Id = Guid.NewGuid(), Name = "Islas Marshall" },
                new Country { Id = Guid.NewGuid(), Name = "Mauricio" },
                new Country { Id = Guid.NewGuid(), Name = "Mauritania" },
                new Country { Id = Guid.NewGuid(), Name = "México" },
                new Country { Id = Guid.NewGuid(), Name = "Micronesia" },
                new Country { Id = Guid.NewGuid(), Name = "Moldavia" },
                new Country { Id = Guid.NewGuid(), Name = "Mónaco" },
                new Country { Id = Guid.NewGuid(), Name = "Mongolia" },
                new Country { Id = Guid.NewGuid(), Name = "Montenegro" },
                new Country { Id = Guid.NewGuid(), Name = "Mozambique" },
                new Country { Id = Guid.NewGuid(), Name = "Birmania" },
                new Country { Id = Guid.NewGuid(), Name = "Namibia" },
                new Country { Id = Guid.NewGuid(), Name = "Nauru" },
                new Country { Id = Guid.NewGuid(), Name = "Nepal" },
                new Country { Id = Guid.NewGuid(), Name = "Nicaragua" },
                new Country { Id = Guid.NewGuid(), Name = "Níger" },
                new Country { Id = Guid.NewGuid(), Name = "Nigeria" },
                new Country { Id = Guid.NewGuid(), Name = "Noruega" },
                new Country { Id = Guid.NewGuid(), Name = "Nueva Zelanda" },
                new Country { Id = Guid.NewGuid(), Name = "Omán" },
                new Country { Id = Guid.NewGuid(), Name = "Países Bajos" },
                new Country { Id = Guid.NewGuid(), Name = "Pakistán" },
                new Country { Id = Guid.NewGuid(), Name = "Palaos" },
                new Country { Id = Guid.NewGuid(), Name = "Panamá" },
                new Country { Id = Guid.NewGuid(), Name = "Papúa Nueva Guinea" },
                new Country { Id = Guid.NewGuid(), Name = "Paraguay" },
                new Country { Id = Guid.NewGuid(), Name = "Perú" },
                new Country { Id = Guid.NewGuid(), Name = "Polonia" },
                new Country { Id = Guid.NewGuid(), Name = "Portugal" },
                new Country { Id = Guid.NewGuid(), Name = "Qatar" },
                new Country { Id = Guid.NewGuid(), Name = "Reino Unido" },
                new Country { Id = Guid.NewGuid(), Name = "República Centroafricana" },
                new Country { Id = Guid.NewGuid(), Name = "República Dominicana" },
                new Country { Id = Guid.NewGuid(), Name = "Rumanía / Rumania" },
                new Country { Id = Guid.NewGuid(), Name = "Rusia" },
                new Country { Id = Guid.NewGuid(), Name = "Ruanda" },
                new Country { Id = Guid.NewGuid(), Name = "San Cristóbal y Nieves" },
                new Country { Id = Guid.NewGuid(), Name = "Islas Salomón" },
                new Country { Id = Guid.NewGuid(), Name = "Samoa" },
                new Country { Id = Guid.NewGuid(), Name = "San Marino" },
                new Country { Id = Guid.NewGuid(), Name = "Santa Lucía" },
                new Country { Id = Guid.NewGuid(), Name = "Ciudad del Vaticano" },
                new Country { Id = Guid.NewGuid(), Name = "Santo Tomé y Príncipe" },
                new Country { Id = Guid.NewGuid(), Name = "San Vicente y las Granadinas" },
                new Country { Id = Guid.NewGuid(), Name = "Senegal" },
                new Country { Id = Guid.NewGuid(), Name = "Serbia" },
                new Country { Id = Guid.NewGuid(), Name = "Seychelles" },
                new Country { Id = Guid.NewGuid(), Name = "Sierra Leona" },
                new Country { Id = Guid.NewGuid(), Name = "Singapur" },
                new Country { Id = Guid.NewGuid(), Name = "Siria" },
                new Country { Id = Guid.NewGuid(), Name = "Somalia" },
                new Country { Id = Guid.NewGuid(), Name = "Sri Lanka" },
                new Country { Id = Guid.NewGuid(), Name = "Sudáfrica" },
                new Country { Id = Guid.NewGuid(), Name = "Sudán" },
                new Country { Id = Guid.NewGuid(), Name = "Sudán del Sur" },
                new Country { Id = Guid.NewGuid(), Name = "Suecia" },
                new Country { Id = Guid.NewGuid(), Name = "Suiza" },
                new Country { Id = Guid.NewGuid(), Name = "Surinam" },
                new Country { Id = Guid.NewGuid(), Name = "Suazilandia" },
                new Country { Id = Guid.NewGuid(), Name = "Tailandia" },
                new Country { Id = Guid.NewGuid(), Name = "Tanzania" },
                new Country { Id = Guid.NewGuid(), Name = "Tayikistán" },
                new Country { Id = Guid.NewGuid(), Name = "Timor Oriental" },
                new Country { Id = Guid.NewGuid(), Name = "Togo" },
                new Country { Id = Guid.NewGuid(), Name = "Tonga" },
                new Country { Id = Guid.NewGuid(), Name = "Trinidad y Tobago" },
                new Country { Id = Guid.NewGuid(), Name = "Túnez" },
                new Country { Id = Guid.NewGuid(), Name = "Turkmenistán" },
                new Country { Id = Guid.NewGuid(), Name = "Turquía" },
                new Country { Id = Guid.NewGuid(), Name = "Tuvalu" },
                new Country { Id = Guid.NewGuid(), Name = "Ucrania" },
                new Country { Id = Guid.NewGuid(), Name = "Uganda" },
                new Country { Id = Guid.NewGuid(), Name = "Uruguay" },
                new Country { Id = Guid.NewGuid(), Name = "Uzbekistán" },
                new Country { Id = Guid.NewGuid(), Name = "Vanuatu" },
                new Country { Id = Guid.NewGuid(), Name = "Venezuela" },
                new Country { Id = Guid.NewGuid(), Name = "Vietnam" },
                new Country { Id = Guid.NewGuid(), Name = "Yemen" },
                new Country { Id = Guid.NewGuid(), Name = "Zambia" },
                new Country { Id = Guid.NewGuid(), Name = "Zimbabue" });

            modelBuilder.Entity<Customer>().Property(a => a.TradeName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.FiscalName).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(a => a.Nif).IsRequired().HasMaxLength(9);
            modelBuilder.Entity<Customer>().Property(a => a.Phone).IsRequired();
            modelBuilder.Entity<Customer>().Property(a => a.Email).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Employee>().Property(e => e.Job).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnType("decimal(8,2)").IsRequired();

            modelBuilder.Entity<Order>().Property(e => e.Priority).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Status).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.Iva).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.EntryDate).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.AssignamentDate).IsRequired();
            modelBuilder.Entity<Order>().Property(e => e.TerminationDate).IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customer)
                .WithMany(a => a.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>().Property(e => e.Discount).HasColumnType("decimal(8,2)").IsRequired();
            modelBuilder.Entity<OrderItem>().Property(e => e.Quantity).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.Dni).HasColumnType("varchar(9)").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Surname).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Phone).IsRequired(); 
            modelBuilder.Entity<Person>().HasIndex(p => p.Dni).IsUnique();
            modelBuilder.Entity<Person>()
                .HasOne(e => e.User)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("text").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Stock).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(8,2)").IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<User>().ToTable("User");
            

        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var result = await base.SaveChangesAsync();
                return result;
            }
            catch(Exception e)
            {
                Console.Write(e);
            }

            return 0;
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public async Task Commit()
        {
            try
            {
                await base.SaveChangesAsync();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
