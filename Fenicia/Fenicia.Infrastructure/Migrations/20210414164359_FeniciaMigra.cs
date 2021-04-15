using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fenicia.Infrastructure.Migrations
{
    public partial class FeniciaMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FiscalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dni = table.Column<string>(type: "varchar(9)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignamentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3e14a0da-01c1-4d44-bd98-2474f2edca00"), "Afganistán" },
                    { new Guid("ec626bab-ac12-4391-9e24-9703c6351f63"), "Mozambique" },
                    { new Guid("f5e77233-59d7-4996-b7a8-aeaddc43f591"), "Birmania" },
                    { new Guid("5f7ba73e-8319-4219-aac1-884c0a7d0b78"), "Namibia" },
                    { new Guid("968f0fed-7db1-400a-943f-000aa68f0e3e"), "Nauru" },
                    { new Guid("83703175-fd00-47b0-a656-4b95fd36c92f"), "Nepal" },
                    { new Guid("81f40cd8-98dc-435c-8a99-a6aa239ffaeb"), "Nicaragua" },
                    { new Guid("4ec62423-f74d-46ed-aea1-97eabe5332cf"), "Níger" },
                    { new Guid("042c28c1-a1ad-40a8-a7f8-dab6e1f89ef1"), "Nigeria" },
                    { new Guid("55824565-96b4-403e-9607-715fae2ea988"), "Noruega" },
                    { new Guid("37afb7f3-d59e-461f-9574-ba79e9427ee8"), "Montenegro" },
                    { new Guid("06dffe94-d5e1-4ebc-b858-41d253fb1679"), "Nueva Zelanda" },
                    { new Guid("e570d276-f41d-4e45-840e-288bc95a7377"), "Países Bajos" },
                    { new Guid("11018db2-67aa-4d1a-a528-01f4f84dc00c"), "Pakistán" },
                    { new Guid("166db2cc-ade7-47e7-9a0c-aa433e9fd391"), "Palaos" },
                    { new Guid("d0e5b10e-1c9d-4eb9-bed0-48b49bca37b9"), "Panamá" },
                    { new Guid("51e7c80c-904a-4628-8f20-9bfdd3aa7297"), "Papúa Nueva Guinea" },
                    { new Guid("b7ae1586-bdd2-4533-b1df-bbc5a1190b64"), "Paraguay" },
                    { new Guid("a8dc0ed6-3300-4794-b852-461c91f326d8"), "Perú" },
                    { new Guid("00ec51b3-36ca-45c6-91ad-c51571b66fc2"), "Polonia" },
                    { new Guid("8228c510-bc34-4724-89c0-f321b2a640a6"), "Portugal" },
                    { new Guid("f907a58d-0190-4978-840e-83599e23a0ef"), "Omán" },
                    { new Guid("2145090a-0e49-4489-89fb-5392b80e488c"), "Mongolia" },
                    { new Guid("8d9de9dc-a101-4d17-a6e3-0b454ded2e10"), "Mónaco" },
                    { new Guid("1e4edfb4-2305-41e5-8ba4-abaaac5bba39"), "Moldavia" },
                    { new Guid("97e2713d-d1ca-47bf-b8fa-a2999a713c2a"), "Lesoto" },
                    { new Guid("bdacf0a2-6ef7-4392-9d84-1734aa53ed05"), "Letonia" },
                    { new Guid("cc315e4d-657c-4d4b-bd1c-26e4e8dc56bb"), "Líbano" },
                    { new Guid("f355d332-97a3-4db6-9759-bf2cd4f499d3"), "Liberia" },
                    { new Guid("d3f8b22e-958c-41b3-99ed-24e549fba133"), "Libia" },
                    { new Guid("01ab04ef-6edc-4e42-84fc-006f3a46a159"), "Liechtenstein" },
                    { new Guid("c6b80355-1e8b-41e2-af4c-eaaa2691ec30"), "Lituania" },
                    { new Guid("33f436ab-fcdc-4ff4-bd90-c22078c349a4"), "Luxemburgo" },
                    { new Guid("b601126b-1ddb-4011-8a61-2c430c471281"), "Macedonia" },
                    { new Guid("fac4eb4b-cae8-4a4a-b4a6-4e4db167d902"), "Madagascar" },
                    { new Guid("56ad51a4-c1ce-4dac-aad5-1b3ad375bf15"), "Malasia" },
                    { new Guid("5cfe799f-4869-4f44-8892-9aa8b4790338"), "Malaui" },
                    { new Guid("0c86c6ba-3711-4ce8-9c25-736206611cd6"), "Maldivas" },
                    { new Guid("26d3921e-2f0d-4c17-ab26-37fbb4986af3"), "Mali / Malí" },
                    { new Guid("22eec806-cd7e-4d76-9f6e-ef6802579384"), "Malta" },
                    { new Guid("f8d8b6fa-7d15-4343-b25f-e98304bab76c"), "Marruecos" },
                    { new Guid("0207fd06-99d6-4178-baca-83ce9e73a37c"), "Islas Marshall" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2695fbdb-324e-480d-b113-284d044b6d83"), "Mauricio" },
                    { new Guid("62b199fa-3467-4b03-a884-c758faeda52d"), "Mauritania" },
                    { new Guid("50e327d7-8989-4cbf-a2a0-75cbb73bae38"), "México" },
                    { new Guid("2aabac16-52a4-45a8-ada7-041d73a9512f"), "Micronesia" },
                    { new Guid("baf25e11-b12b-43ac-8728-1c17343bfe47"), "Qatar" },
                    { new Guid("28d697ce-ea85-4153-aabe-8902abafb0a0"), "Laos" },
                    { new Guid("12fcd3af-7c28-440a-a51a-39fc90fce212"), "Reino Unido" },
                    { new Guid("aef1fdc0-aef3-4438-bb49-d6c5be4762cc"), "República Dominicana" },
                    { new Guid("c65bc010-3e72-4eaf-a533-77109b4a5664"), "Suazilandia" },
                    { new Guid("c5c84c5f-cedb-4dfc-a028-83b6852499e5"), "Tailandia" },
                    { new Guid("52654f13-f1d4-44b9-92ef-ef5b363cc0d9"), "Tanzania" },
                    { new Guid("4a8c0704-5eca-46e8-ac6d-bc3ef4a633d8"), "Tayikistán" },
                    { new Guid("261e9d62-5721-4c0c-bc96-e4ac09af726e"), "Timor Oriental" },
                    { new Guid("2b3a06ce-1055-481e-ae9b-92d3e8faef2e"), "Togo" },
                    { new Guid("8e9cac2d-acb7-49b5-a73b-328955d11d1b"), "Tonga" },
                    { new Guid("5fffbd9c-9a1d-4aca-9c4f-10a327a425e0"), "Trinidad y Tobago" },
                    { new Guid("cf2d12cf-6326-428a-a858-2e65ff4a81d6"), "Túnez" },
                    { new Guid("71e2c724-e9bb-4ff1-a306-0b0e3ba35496"), "Surinam" },
                    { new Guid("dafdbc62-137a-4f0e-912c-718cc74c789b"), "Turkmenistán" },
                    { new Guid("0a0f1293-de68-4e48-aaf7-bf56a3a08f96"), "Tuvalu" },
                    { new Guid("f04149aa-765b-4a8a-90e8-b4d1d2608cd1"), "Ucrania" },
                    { new Guid("ac2d0298-3989-47b9-b983-cf9914dc88c3"), "Uganda" },
                    { new Guid("c2c69859-510b-4ed2-9ba3-b51cc8de0f06"), "Uruguay" },
                    { new Guid("c146a58b-1fc1-4f94-b943-833717f7c799"), "Uzbekistán" },
                    { new Guid("5a27b3ee-9c9b-4965-b9d3-653c8dfe5f4d"), "Vanuatu" },
                    { new Guid("b4e793a4-c379-47be-aa31-9d3107fc010f"), "Venezuela" },
                    { new Guid("24d1fb63-6336-4f29-af05-687ba00ebd16"), "Vietnam" },
                    { new Guid("22853c26-04d3-4999-a2de-74bd4e7e6d22"), "Yemen" },
                    { new Guid("d017a44f-d307-4f89-a2f5-5f71771ad1a0"), "Turquía" },
                    { new Guid("2f937d95-7059-40ef-86af-43158d382c72"), "Suiza" },
                    { new Guid("e9d2ef7a-f621-4586-abd2-c0d9addb81e6"), "Suecia" },
                    { new Guid("639b4e2e-4e68-4d47-b8fe-d3537877b35d"), "Sudán del Sur" },
                    { new Guid("6d8a035a-728e-4a0a-ae29-1ed2b36f1b18"), "Rumanía / Rumania" },
                    { new Guid("77013511-99bb-409c-acab-d74e52f59dfa"), "Rusia" },
                    { new Guid("da3c00d2-afad-44be-be5a-245c4bcafc13"), "Ruanda" },
                    { new Guid("47f457e7-f7ea-4aec-ab33-852b8f0e3bfc"), "San Cristóbal y Nieves" },
                    { new Guid("88bd42a3-dd59-48ac-a865-77fa1e3f5a3c"), "Islas Salomón" },
                    { new Guid("2ad9f129-959f-4639-b0bd-ffa7ff15c616"), "Samoa" },
                    { new Guid("8bce79fb-4899-41b8-b938-12bfab220115"), "San Marino" },
                    { new Guid("14804a7a-df87-41a4-8f6d-6c6e5639bd4f"), "Santa Lucía" },
                    { new Guid("c6b28736-a46b-4dc3-a0c1-5c55090e8455"), "Ciudad del Vaticano" },
                    { new Guid("a27de31d-bbe6-4280-b581-964d00fcf988"), "Santo Tomé y Príncipe" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f51327c-04e8-4588-ae06-aea0a4035634"), "San Vicente y las Granadinas" },
                    { new Guid("375f9569-abd7-4431-b160-8d7b354a31e7"), "Senegal" },
                    { new Guid("86de924f-e2ab-4fac-a39a-ae653759baed"), "Serbia" },
                    { new Guid("5e856b53-a0af-4d68-8331-8030cbf0d5d7"), "Seychelles" },
                    { new Guid("5e1ac8eb-db23-4127-b1e6-4062f44c805b"), "Sierra Leona" },
                    { new Guid("acb1a1c3-336f-4d9b-a9fd-a3e1b3a13395"), "Singapur" },
                    { new Guid("b86a6245-a5b8-4601-a6d9-c563467857ab"), "Siria" },
                    { new Guid("77129136-d214-42dc-9bc4-86fa493063ae"), "Somalia" },
                    { new Guid("16b83289-06e1-40fe-a6b8-3b9a3cb59622"), "Sri Lanka" },
                    { new Guid("36a121e9-333a-40ac-a34d-c36d89358a0b"), "Sudáfrica" },
                    { new Guid("29dadf90-02e6-41e6-9607-44820753fa79"), "Sudán" },
                    { new Guid("85cfcda1-7d8c-414a-9efa-c542ada865b6"), "República Centroafricana" },
                    { new Guid("2608a230-5135-47bb-8d11-ff786d088b38"), "Zambia" },
                    { new Guid("9d9a824b-c987-4ed4-b35f-5b3b5606a6ff"), "Kuwait" },
                    { new Guid("52d062af-e05a-4506-b600-f519b9876a5e"), "Kirguistán" },
                    { new Guid("facb408f-bb41-4f16-9a4c-fc66af007550"), "Brunéi" },
                    { new Guid("7cea07d4-c45c-4bce-8020-10dafc3c2a58"), "Bulgaria" },
                    { new Guid("2a4ceacc-6660-4ea6-a74a-0bb45ed9e893"), "Burkina Faso" },
                    { new Guid("4c450d20-811b-4e00-a6ff-78bcd78e0c90"), "Burundi" },
                    { new Guid("fbe42ccf-c1be-4931-ba74-a538b72a7e18"), "Cabo Verde" },
                    { new Guid("92d60af0-9dbd-4d88-a144-7d2eb9645707"), "Camboya" },
                    { new Guid("fb36ce36-2467-4d3d-9ab7-54fe961725a7"), "Camerún" },
                    { new Guid("99466a00-70e1-4525-8c1c-d6f41c1ac29c"), "Canadá" },
                    { new Guid("a2930620-048f-4253-a3cd-310417d10c89"), "Chad" },
                    { new Guid("56a366c0-fddc-4bec-a680-9d30dd8917b7"), "Brasil" },
                    { new Guid("3b4a710a-4ad6-441c-a89d-1845ec69ba58"), "República Checa" },
                    { new Guid("bc2a2d99-e54f-4d88-ae7b-a53829f4c5a1"), "Chile" },
                    { new Guid("6ba42ad1-f86f-4521-bfb6-c7bf6e9b1d78"), "China" },
                    { new Guid("012f88fa-8d11-4e41-bbb3-37d129253bc2"), "Chipre" },
                    { new Guid("4af6bc7a-19fd-4f96-bd63-d166bca4e2e6"), "Colombia" },
                    { new Guid("d53b6b02-03f9-4274-8db5-87575e8a3b21"), "Comoras" },
                    { new Guid("1f1ca746-7d6a-453d-af1c-d164210cb0a5"), "Congo" },
                    { new Guid("5ad4f570-8a13-485f-a792-271ffbc0d723"), "República Democrática del Congo" },
                    { new Guid("6c06edc3-dd78-4a3d-93ca-15aae9f5894e"), "Corea del Norte" },
                    { new Guid("85b87f90-2ee1-4568-91e4-97794c7edad1"), "Corea del Sur" },
                    { new Guid("f36c37be-b6b5-4353-a30a-007977588cbd"), "Chequia" },
                    { new Guid("2a6281e2-85c1-400c-b7f7-61e56bd00add"), "Botsuana" },
                    { new Guid("38f14925-c921-4c3a-a8b8-50d5922f94df"), "Bosnia-Herzegovina" },
                    { new Guid("6360add2-dc84-44a0-af77-fd1ebd08bf8e"), "Bolivia" },
                    { new Guid("e72fca70-89ce-4112-8b05-3fabed59b10b"), "Albania" },
                    { new Guid("3c27e6f9-19b3-453d-a290-ce4c01186956"), "Alemania" },
                    { new Guid("94c4550a-74cf-4ddb-a1bb-0653c637590d"), "Andorra" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("99063ea1-b8a7-466a-a4a4-3475db01f2ab"), "Angola" },
                    { new Guid("f100bf46-312c-40fb-bee0-1653eb8a5cce"), "Antigua y Barbuda" },
                    { new Guid("525ccc19-dcb2-47bd-859e-4cef10dfdaeb"), "Arabia Saudita" },
                    { new Guid("6cb7027c-7439-4117-895e-d63db473f015"), "Argelia" },
                    { new Guid("ed96bc37-0618-47dd-8c2f-51b5ef3aa43a"), "Argentina" },
                    { new Guid("13003134-7a8b-44b5-8226-ad4b5b84730f"), "Armenia" },
                    { new Guid("9422a832-c998-4bf1-9bac-770e44416ff1"), "Australia" },
                    { new Guid("82796056-7341-41cc-9a15-ad131b4b9fc4"), "Austria" },
                    { new Guid("1f71f1c7-73d2-4316-89c3-1380f0fd86d6"), "Azerbaiyán" },
                    { new Guid("2579c1dc-f67c-4fc3-b3e6-490055ee13e8"), "Bahamas" },
                    { new Guid("fce34d30-8e61-4982-8c7e-67280a3b39ba"), "Bahréin" },
                    { new Guid("a7ac6fe9-b090-4a17-a113-3cbb4acc0036"), "Bangladés" },
                    { new Guid("377649ca-5eee-4f79-bf9f-758c83c289a2"), "Barbados" },
                    { new Guid("d4bb9969-cdc6-48b9-aa56-f63dd0449e96"), "Bielorrusia" },
                    { new Guid("4a819bcf-bc84-4265-8fb5-ccb12f7e8949"), "Bélgica" },
                    { new Guid("20a45ab1-7d3d-43bf-940a-d80ff8fae31b"), "Belice" },
                    { new Guid("26daa43b-e137-4b09-81f9-521259d43bad"), "Benín" },
                    { new Guid("dbc9befb-3be6-46ed-bfbf-c9487eddc997"), "Bután" },
                    { new Guid("12f07b3b-1ac5-4b2c-9097-0dcdb26467bc"), "Costa Rica" },
                    { new Guid("95a26994-2498-4dfc-b5aa-9830bd63e954"), "Kiribati" },
                    { new Guid("19a25e54-4df5-41af-864e-9102b07955ac"), "Costa de Marfil" },
                    { new Guid("1e2583fd-d0b5-4036-8779-ab5b9337b07f"), "Cuba" },
                    { new Guid("d3faf34f-8052-48ca-a8f6-8c323c3a4268"), "Guinea" },
                    { new Guid("55cb5ebf-e257-4fde-b8f6-97283305f374"), "Guinea-Bissau" },
                    { new Guid("8bc9d69b-e6f3-4a08-8a5b-71d9b9e86570"), "Guinea Ecuatorial" },
                    { new Guid("c7644f66-e6a6-49a3-be2d-cd3f3f386b28"), "Guyana" },
                    { new Guid("46136e45-d072-4eef-be6d-98f9b6f469de"), "Haití" },
                    { new Guid("8f6189f0-5bea-4acc-8ae4-c01ffb6d5d42"), "Honduras" },
                    { new Guid("eab5992f-7f21-4a8e-9ff6-e4e4ab171ee0"), "Hungría" },
                    { new Guid("61c722f3-8178-4fe8-b736-e043c530bcad"), "India" },
                    { new Guid("ad6c9aef-3804-4159-a9ab-530eb8b18520"), "Indonesia" },
                    { new Guid("be91bbb1-ea19-4fb5-93b4-06dcec117b91"), "Guatemala" },
                    { new Guid("a1b76916-cfa8-43c9-9708-3e4438ea2f9d"), "Irán" },
                    { new Guid("5a8790af-9d6f-4f65-919d-89a8b31bf3a5"), "Irlanda" },
                    { new Guid("e7749b1e-8424-40c3-b4c5-cbd6bdeb70aa"), "Islandia" },
                    { new Guid("90a82f40-6f8d-4ac8-bab5-01c02fb3cd7e"), "Israel" },
                    { new Guid("380de432-35c2-4223-be2c-16321db3d6c2"), "Italia" },
                    { new Guid("108441d9-4b31-4ed5-a5ae-d41243befd87"), "Jamaica" },
                    { new Guid("764fbd43-53f9-4d47-b21a-aaa920063b24"), "Japón" },
                    { new Guid("efe2b337-9094-4d3a-93b9-60325bbee245"), "Jordania" },
                    { new Guid("1a6e64a6-5a8f-4b0a-9ace-8d804553f8b5"), "Kazajistán" },
                    { new Guid("de5af868-eada-4bf4-adfe-d6b2322d2623"), "Kenia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ea009511-9b6a-4145-8bd2-da5bf8d23e8b"), "Iraq" },
                    { new Guid("3a0800ed-1837-427e-93d9-72228691565c"), "Grecia" },
                    { new Guid("ab406fcd-4b5b-4ef2-b29f-6d48f49181e7"), "Granada" },
                    { new Guid("9c4e6cc8-6660-44d9-ba39-fe0f970ecfc1"), "Ghana" },
                    { new Guid("923c1f0e-903a-42f6-b200-339b56fa8d97"), "Dinamarca" },
                    { new Guid("ccb58fc9-bdea-4628-9b71-fc8cc9c53dea"), "Yibuti" },
                    { new Guid("7bf43d26-7729-4992-856b-01cd0cda93b2"), "Dominica" },
                    { new Guid("c7d63674-d278-446b-9905-63d917b7dd6b"), "Ecuador" },
                    { new Guid("d98718a2-5414-4c65-a7ac-1863aa0349bd"), "Egipto" },
                    { new Guid("dd0a6777-456a-4d40-9649-7d158f3a32c7"), "El Salvador" },
                    { new Guid("80669334-3b88-4d82-b859-e169d58a2166"), "Emiratos Árabes Unidos" },
                    { new Guid("a548aa82-0259-48e8-a26e-598a3d6d2139"), "Eritrea" },
                    { new Guid("1588460b-04d3-4f34-b60a-460e3d44a900"), "Eslovaquia" },
                    { new Guid("47137ec5-514d-4c03-b03f-a0e555fff5d2"), "Eslovenia" },
                    { new Guid("c55305af-f895-4272-93ba-2625be3ad7da"), "España" },
                    { new Guid("fe4411fa-12a3-4b65-ade5-8576d5970ff9"), "Estados Unidos" },
                    { new Guid("4361531a-47a2-4b6e-80f7-d2f2683d9fd4"), "Estonia" },
                    { new Guid("ab87b140-29f5-455f-8477-a51144848d61"), "Etiopía" },
                    { new Guid("ede962aa-1ff4-494c-8704-f2dbb33b5868"), "Fiyi" },
                    { new Guid("1a91b2be-c817-424f-b68b-769289f316ea"), "Filipinas" },
                    { new Guid("833277ab-c65f-4226-8806-a698ba407451"), "Finlandia" },
                    { new Guid("caefbb6b-621d-40d1-b800-fd50c3c87d07"), "Francia" },
                    { new Guid("11d18cb2-25ad-439a-a69a-21853d7a9a69"), "Gabón" },
                    { new Guid("00044285-e211-46b3-98fc-4256be85520a"), "Gambia" },
                    { new Guid("bc7a0796-4440-43ab-85de-0087ba9e93d7"), "Georgia" },
                    { new Guid("2f9ed444-e560-43bf-af85-eea8bd36d5fb"), "Croacia" },
                    { new Guid("9503b8ef-3c01-41ff-8743-33b5514401a7"), "Zimbabue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryAddressId",
                table: "Order",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Dni",
                table: "Person",
                column: "Dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
