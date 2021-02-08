﻿// <auto-generated />
using System;
using Fenicia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fenicia.Infrastructure.Migrations
{
    [DbContext(typeof(FeniciaDbContext))]
    partial class FeniciaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Fenicia.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeliveryAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Door")
                        .HasMaxLength(25)
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasMaxLength(25)
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasMaxLength(25)
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ZipCode")
                        .HasMaxLength(25)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("idCountry")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("idCountry");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssignamentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("NumberItems")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(8,2)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.DeliveryAddress", b =>
                {
                    b.HasBaseType("Fenicia.Domain.Entities.Address");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CustomerId");

                    b.ToTable("DeliveryAddress");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Customer", b =>
                {
                    b.HasBaseType("Fenicia.Domain.Entities.User");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Fax")
                        .HasColumnType("int");

                    b.Property<Guid>("FiscalAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FiscalName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Web")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasIndex("FiscalAddressId")
                        .IsUnique()
                        .HasFilter("[FiscalAddressId] IS NOT NULL");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Person", b =>
                {
                    b.HasBaseType("Fenicia.Domain.Entities.User");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasIndex("AddressId");

                    b.HasIndex("Dni")
                        .IsUnique()
                        .HasFilter("[Dni] IS NOT NULL");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MenuId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Fenicia.Domain.Entities.Person");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Employee", b =>
                {
                    b.HasBaseType("Fenicia.Domain.Entities.Person");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(8,2)");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Address", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.City", "CityAddress")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId");

                    b.Navigation("CityAddress");

                    b.Navigation("DeliveryAddress");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.City", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Country", "CountryCity")
                        .WithMany("Cities")
                        .HasForeignKey("idCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryCity");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Order", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.DeliveryAddress", "DeliveryAddress")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DeliveryAddress");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Product", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.DeliveryAddress", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Customer", "Customer")
                        .WithMany("DeliveryAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.Address", null)
                        .WithOne()
                        .HasForeignKey("Fenicia.Domain.Entities.DeliveryAddress", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Address", "FiscalAddress")
                        .WithOne("FiscalAddressCustomer")
                        .HasForeignKey("Fenicia.Domain.Entities.Customer", "FiscalAddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Fenicia.Domain.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("FiscalAddress");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Person", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Fenicia.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Fenicia.Domain.Entities.Person", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Fenicia.Domain.Entities.Menu", "Menu")
                        .WithMany("Persons")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Employee");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Admin", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("Fenicia.Domain.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Fenicia.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("Fenicia.Domain.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Address", b =>
                {
                    b.Navigation("FiscalAddressCustomer");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Menu", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.DeliveryAddress", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Customer", b =>
                {
                    b.Navigation("DeliveryAddresses");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Fenicia.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
