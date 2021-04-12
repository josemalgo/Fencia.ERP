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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    { new Guid("ab6718cb-9c48-4d1f-93e2-054a8a372a7c"), "Afganistán" },
                    { new Guid("0d10c6bf-0924-4d0f-a1a5-c23be73e9a21"), "Mozambique" },
                    { new Guid("73df3ffc-add9-4027-baa7-e2762b9e0bf6"), "Birmania" },
                    { new Guid("8960ba8c-5f3c-4d68-bcb1-010393229e8d"), "Namibia" },
                    { new Guid("620bb47a-c82b-4bf3-84ff-de5d2613c48e"), "Nauru" },
                    { new Guid("699a343d-fcd2-4293-b93f-863ef01bab42"), "Nepal" },
                    { new Guid("3c0bf3cc-830a-4413-a563-39141e3a599b"), "Nicaragua" },
                    { new Guid("a6469bee-4974-408d-954b-ff8be79010c1"), "Níger" },
                    { new Guid("eb317e34-f816-429e-bf82-f89cd65bcc5e"), "Nigeria" },
                    { new Guid("9e5412f4-8e6d-4853-8c4d-15ce13668526"), "Noruega" },
                    { new Guid("5240ab90-9c16-4253-b04d-76dc6740a37a"), "Montenegro" },
                    { new Guid("340d3b79-7e17-47b7-a502-eca9403e2b19"), "Nueva Zelanda" },
                    { new Guid("d3d98804-169c-4082-84fb-7216e503f1cc"), "Países Bajos" },
                    { new Guid("f17a1b76-aade-4e5c-b742-5c6d43e08895"), "Pakistán" },
                    { new Guid("30c3deb9-f966-4200-85fc-86a6e8f0c403"), "Palaos" },
                    { new Guid("f6b58ba7-bcfe-423e-96d8-ee15762591e0"), "Panamá" },
                    { new Guid("8f915d76-af0d-4a43-a049-5417407f2f42"), "Papúa Nueva Guinea" },
                    { new Guid("cccf05b9-8f66-474f-84fb-b16da623237b"), "Paraguay" },
                    { new Guid("b2cc0662-d7ae-4865-bd71-bf29471166a0"), "Perú" },
                    { new Guid("249e9947-71d5-4036-8ea6-fc95d4407579"), "Polonia" },
                    { new Guid("841d5342-7993-4f54-b693-e45a61f49c98"), "Portugal" },
                    { new Guid("135c159d-e542-4e20-bbc1-38d94a92ed5c"), "Omán" },
                    { new Guid("586272d5-212e-4682-8948-9b3240481eec"), "Mongolia" },
                    { new Guid("d00bf8f9-6e9a-41f8-9f0c-95d0dd60b732"), "Mónaco" },
                    { new Guid("c4806184-e9ca-486f-94bf-6e60af30b7cc"), "Moldavia" },
                    { new Guid("6bee1756-635b-4214-9d8a-63ddcd2bcb28"), "Lesoto" },
                    { new Guid("1ec6fa79-f3c3-4510-af0f-23503f6f372c"), "Letonia" },
                    { new Guid("e96668b8-899e-4ea6-ae69-2a58bce95452"), "Líbano" },
                    { new Guid("ca24177e-9337-449c-87a9-03443932d988"), "Liberia" },
                    { new Guid("f9db3824-e93d-46dd-9575-a0b5d781deec"), "Libia" },
                    { new Guid("32843e6d-493b-448a-9d65-724ccdef5f91"), "Liechtenstein" },
                    { new Guid("aaa866c9-dd09-4089-a889-1d79032a8cf7"), "Lituania" },
                    { new Guid("d1c8aebb-c33a-40aa-ba58-f307d081585f"), "Luxemburgo" },
                    { new Guid("9231763c-7041-4038-8854-5f7d43f3c26a"), "Macedonia" },
                    { new Guid("cfea9523-3ad2-4f93-93c2-c57d85af770d"), "Madagascar" },
                    { new Guid("8cb51b92-a418-4bb6-9413-54b945cf6d16"), "Malasia" },
                    { new Guid("d3cef2c8-649e-4585-8253-625cbf754f27"), "Malaui" },
                    { new Guid("2633923d-e028-4c62-9f25-220f1488a87d"), "Maldivas" },
                    { new Guid("484b9621-d96a-4d0e-9864-ad98943cf950"), "Mali / Malí" },
                    { new Guid("48104a6f-b356-463c-9376-40c9f4af9185"), "Malta" },
                    { new Guid("802655e0-08e0-4dae-82e2-ef1059a5a28e"), "Marruecos" },
                    { new Guid("2d16799c-2d1f-45de-b24e-95489c0b0d07"), "Islas Marshall" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01d1f461-24c4-46a7-82d1-8e8399e7637a"), "Mauricio" },
                    { new Guid("bc2d20a3-11db-4d5f-9193-25a7ce4bac36"), "Mauritania" },
                    { new Guid("b2e5266a-7779-40bc-8745-ca209746d7ec"), "México" },
                    { new Guid("a0ba2266-2790-4ec6-bc58-7f203255e5fb"), "Micronesia" },
                    { new Guid("1274d3d3-7222-4377-b734-5bb6d8aa1303"), "Qatar" },
                    { new Guid("483cf271-21c2-4bd9-9a44-11af529ec3e3"), "Laos" },
                    { new Guid("42cea4bb-06db-4400-a883-d972ae5a54a1"), "Reino Unido" },
                    { new Guid("0f88de1c-d482-4091-b8a5-13e1543dbe3a"), "República Dominicana" },
                    { new Guid("0d71de04-6a49-44c8-ab89-ac44adbfa014"), "Suazilandia" },
                    { new Guid("1965ac7e-747d-419b-9178-929492bad0f5"), "Tailandia" },
                    { new Guid("9d991a81-850e-4c7d-a574-44e1be4c7124"), "Tanzania" },
                    { new Guid("2ea73ec0-921b-496d-8d64-f74b681902fa"), "Tayikistán" },
                    { new Guid("c88c9560-f38a-43ca-b650-4b4ae1b4f9fd"), "Timor Oriental" },
                    { new Guid("22e9b80f-697c-4bad-9824-0f33786c667b"), "Togo" },
                    { new Guid("ef2238a3-a8bc-497b-9bee-3137f5df111f"), "Tonga" },
                    { new Guid("f226809c-e87e-489a-a6aa-63e7315a742a"), "Trinidad y Tobago" },
                    { new Guid("4b5c98dd-16f8-4e50-b40b-a6b916de3c91"), "Túnez" },
                    { new Guid("ad5ff1ab-0ac5-433f-97ae-6bdd9c1fae28"), "Surinam" },
                    { new Guid("f015db52-cbae-452d-8137-8929ddd364b2"), "Turkmenistán" },
                    { new Guid("8d58ef6a-5580-452b-8df2-6c18a3db0dde"), "Tuvalu" },
                    { new Guid("d9f9700e-7885-4ac6-9fc8-3b7bdd88c034"), "Ucrania" },
                    { new Guid("f028853c-a04b-45be-92b3-229ea952fcc4"), "Uganda" },
                    { new Guid("d2da0993-2cdb-44b7-a6a8-00b8133ce8b9"), "Uruguay" },
                    { new Guid("397d6be0-aeeb-4e1c-b554-5a7ed9202210"), "Uzbekistán" },
                    { new Guid("abd3dcd1-a7c9-44f2-88e4-37e953c519ba"), "Vanuatu" },
                    { new Guid("8cd25faf-662e-4fe5-8e4e-ec9ab7bb9377"), "Venezuela" },
                    { new Guid("b2fb5522-dcf9-4640-ac4a-9dd71d1e8d77"), "Vietnam" },
                    { new Guid("9db556fa-dfc5-4c6b-ae1f-c5d1d6cc787c"), "Yemen" },
                    { new Guid("a943ebdf-6434-46e0-b028-417ebdcc8cf1"), "Turquía" },
                    { new Guid("9c4cb223-d57d-41e6-a3ef-eaf50bd5461c"), "Suiza" },
                    { new Guid("f6d106eb-7551-4fa7-b565-4d41e8eeac4d"), "Suecia" },
                    { new Guid("79c67972-30aa-4550-8bdf-8f31d00c8e4c"), "Sudán del Sur" },
                    { new Guid("ee7760c6-f860-448d-88df-ab07b012a59c"), "Rumanía / Rumania" },
                    { new Guid("4d922ef0-0a45-41e6-b317-ba6fcf7e475b"), "Rusia" },
                    { new Guid("5dc6729b-1fdf-4751-a164-bad936f2c239"), "Ruanda" },
                    { new Guid("0fa11520-fe22-4c8b-970e-160e9ef12fe6"), "San Cristóbal y Nieves" },
                    { new Guid("ee4adcd1-e59f-4b8f-81a8-2d1e2a31f44c"), "Islas Salomón" },
                    { new Guid("30a4d7f8-ee79-4399-9911-8c2d70bdb944"), "Samoa" },
                    { new Guid("aab0c324-717d-4b35-b979-76f9e2da27e7"), "San Marino" },
                    { new Guid("6bf855b9-de24-4ae0-a789-1e48500f2a79"), "Santa Lucía" },
                    { new Guid("12126433-ee12-4891-8c99-48007e8e5d98"), "Ciudad del Vaticano" },
                    { new Guid("3e699c6b-20ba-4495-936d-07a74c15b210"), "Santo Tomé y Príncipe" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4d0a5b19-43c4-43a5-843e-6cc63f1115a9"), "San Vicente y las Granadinas" },
                    { new Guid("e6e5a53c-85db-4a8d-9608-a1b9b59b8f5f"), "Senegal" },
                    { new Guid("83d2802f-2ecd-4668-9a0d-bb01456e2de5"), "Serbia" },
                    { new Guid("faef29ee-7189-4311-a141-3da1a4a89d40"), "Seychelles" },
                    { new Guid("56c9a19b-e56a-4ed9-8114-f2b19a5dba4c"), "Sierra Leona" },
                    { new Guid("dc435b40-d1b4-4d51-9831-fda9e555c4a4"), "Singapur" },
                    { new Guid("aa8624e9-fc31-4d6e-9021-a7e7ffec7ceb"), "Siria" },
                    { new Guid("d23e3e0e-9141-468a-9c48-cebdb629b5d4"), "Somalia" },
                    { new Guid("de4fed0d-08fa-410b-aab8-43eaa0679b35"), "Sri Lanka" },
                    { new Guid("40d694d5-43e2-4d59-98b7-83f54ab67549"), "Sudáfrica" },
                    { new Guid("579703cb-7bef-4ccd-b142-c34d078730ae"), "Sudán" },
                    { new Guid("95cb14c1-4c0e-4a82-aac1-310f46833175"), "República Centroafricana" },
                    { new Guid("71422e62-fff8-4b02-8e0a-df2df8700246"), "Zambia" },
                    { new Guid("ef65c1f9-e986-49cc-9769-1e581401cc1f"), "Kuwait" },
                    { new Guid("ebf90385-8bce-414b-8a3c-fcb683e224d4"), "Kirguistán" },
                    { new Guid("0a5a887c-95e1-4ae4-96d0-77465752c4c2"), "Brunéi" },
                    { new Guid("9d40aa52-a308-46f6-b202-011b2b504025"), "Bulgaria" },
                    { new Guid("fc67b721-057b-445a-88b6-901518ebe52c"), "Burkina Faso" },
                    { new Guid("7cfe059c-f56a-4420-856e-4e0659edc325"), "Burundi" },
                    { new Guid("991c2e92-da48-440b-9713-8faf72e083f8"), "Cabo Verde" },
                    { new Guid("e18ec8d8-320c-4ce7-a493-2a6329c6a96a"), "Camboya" },
                    { new Guid("c774b190-b65b-4bdc-8ed0-6a8ab14901c2"), "Camerún" },
                    { new Guid("705e1518-a782-4c86-8792-d18b02bcd27c"), "Canadá" },
                    { new Guid("deee4e2d-a11f-4a30-bc38-7f3e1b5942ba"), "Chad" },
                    { new Guid("40e76528-6fdd-4aac-a18c-422ea8f049f6"), "Brasil" },
                    { new Guid("8cc6f7b9-0bfe-4ea7-8d8f-39836d4a7c37"), "República Checa" },
                    { new Guid("3ac4c141-e5cd-4494-b062-67784cf36fff"), "Chile" },
                    { new Guid("c9cc2877-23de-477a-81b9-68e019692d67"), "China" },
                    { new Guid("8f0dfe82-bca5-4900-9b74-8d2065e3ea36"), "Chipre" },
                    { new Guid("2698cec4-9346-447b-bd2c-b430404bd3ef"), "Colombia" },
                    { new Guid("59e27738-8fa9-42f3-b2ff-6f8feadeaeb9"), "Comoras" },
                    { new Guid("48c370ba-9e41-41ba-8664-d6ad967da3a0"), "Congo" },
                    { new Guid("3c609534-713a-41b1-8130-626fca744073"), "República Democrática del Congo" },
                    { new Guid("6540a69b-361e-480e-bc94-3caf60063f30"), "Corea del Norte" },
                    { new Guid("e13be4c4-8a85-409d-ac2e-889feafca72a"), "Corea del Sur" },
                    { new Guid("92dd7ac7-5108-4f5b-afd0-de1b0b135695"), "Chequia" },
                    { new Guid("54b9f137-d992-4b21-86f5-47f0e294fffb"), "Botsuana" },
                    { new Guid("95f72b29-a10b-4e5d-86cc-6dc5fa88aef6"), "Bosnia-Herzegovina" },
                    { new Guid("68aa711d-a277-43d7-94de-8acb6ee515c9"), "Bolivia" },
                    { new Guid("cc2026a0-904a-46d4-a6dc-cf203c481a6d"), "Albania" },
                    { new Guid("7f6ca64b-6a8b-4da5-b281-6fbd92434697"), "Alemania" },
                    { new Guid("5df47488-5628-4bfd-99c4-4f03e7658c09"), "Andorra" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e8b52c26-9738-4bff-a2ec-97bed2616e8e"), "Angola" },
                    { new Guid("a8e9e697-71cf-4246-8bbe-921810270d8a"), "Antigua y Barbuda" },
                    { new Guid("f7c1d676-5560-4bd8-b6d4-48305b38390f"), "Arabia Saudita" },
                    { new Guid("4f454fae-f7fe-4fa2-9697-91884fae88fa"), "Argelia" },
                    { new Guid("733f1055-9ff6-4f06-aa7e-32a79dbefd63"), "Argentina" },
                    { new Guid("2307b9a6-adfc-47fc-9210-633432526a20"), "Armenia" },
                    { new Guid("642240cc-a219-4793-891c-24a4b3957a13"), "Australia" },
                    { new Guid("cc082d9a-c94c-48f1-b88d-b99bc40e2f23"), "Austria" },
                    { new Guid("e4ff9de0-fd24-4dc8-abc2-73cb7c1275f3"), "Azerbaiyán" },
                    { new Guid("ddab2f5a-8e16-4e5f-9c27-403bdd4d3e34"), "Bahamas" },
                    { new Guid("9c99d191-881f-4b16-826f-e0ab7ed1f465"), "Bahréin" },
                    { new Guid("4b24195a-8e60-4ab1-864b-88d2d7dc6dac"), "Bangladés" },
                    { new Guid("e17098f1-2696-4c1e-ac04-f2cb56bd4f01"), "Barbados" },
                    { new Guid("5a756144-9114-48ec-a934-57fda140d501"), "Bielorrusia" },
                    { new Guid("1eb15032-5413-46b7-ad43-0eaa1bbbac56"), "Bélgica" },
                    { new Guid("8b51aae7-adf5-43e6-8b07-77e03d93364c"), "Belice" },
                    { new Guid("ed571071-e536-4da7-825e-3fec1887763b"), "Benín" },
                    { new Guid("bac55b5a-7dbf-4ddb-a5ce-39c89568b7ea"), "Bután" },
                    { new Guid("9a492da4-9e79-4407-ba5c-a52cf0578931"), "Costa Rica" },
                    { new Guid("9163c287-85aa-4733-8dde-82c99234b323"), "Kiribati" },
                    { new Guid("b2f8f6f8-c42b-408f-b45b-7812c3dfc0ab"), "Costa de Marfil" },
                    { new Guid("65f00b4d-e25b-44b7-9bc5-da783705e954"), "Cuba" },
                    { new Guid("11ed02bc-38c0-4517-8c96-9875f32c07f2"), "Guinea" },
                    { new Guid("ebae29ad-2167-4ee8-b78b-3a6ce8600db1"), "Guinea-Bissau" },
                    { new Guid("b111f4aa-23df-438a-b323-51a06192879f"), "Guinea Ecuatorial" },
                    { new Guid("eb41fbd5-50bb-4492-ae6b-61c9ac53d1a4"), "Guyana" },
                    { new Guid("7555d1ef-dc21-4131-8cc9-a58d0e5b4718"), "Haití" },
                    { new Guid("2fc9ef03-ac53-4b93-9d23-05f1cf3d392f"), "Honduras" },
                    { new Guid("8b40dd24-cece-416e-b5c7-4ce51c534fca"), "Hungría" },
                    { new Guid("a0451eda-a214-460b-9e05-8c86492f09d0"), "India" },
                    { new Guid("b3b8e6bc-b443-4d98-b851-253b1c806063"), "Indonesia" },
                    { new Guid("563e7469-3325-40cb-b8bf-0bc33bb2c59b"), "Guatemala" },
                    { new Guid("afd61c8e-6863-42bc-8939-675dffc06e4e"), "Irán" },
                    { new Guid("8fd22101-9c70-4bc0-838b-1ed736e65d07"), "Irlanda" },
                    { new Guid("22165e34-97b7-4673-8eb8-f82344c0aa3b"), "Islandia" },
                    { new Guid("5cd9c955-6d19-4fe1-a0c2-4a82188a1ef4"), "Israel" },
                    { new Guid("0d7291d5-c72b-4ad8-aa3e-1684609e8d6b"), "Italia" },
                    { new Guid("4cd25471-ad41-4d0c-829e-af461a63e861"), "Jamaica" },
                    { new Guid("23fc28b6-6a7c-439b-aac1-b816e3992114"), "Japón" },
                    { new Guid("2905185c-4a0b-418f-bfed-225009067aca"), "Jordania" },
                    { new Guid("3dce0a05-5b9c-4b9f-900b-fa96be104e05"), "Kazajistán" },
                    { new Guid("fcd62bd0-0b87-401f-960e-b8f1c8b7e78f"), "Kenia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2abe7fd5-ef52-4932-bf08-8d35fcf5032a"), "Iraq" },
                    { new Guid("f388bab9-d8f3-4ee3-b230-19c6b21529ef"), "Grecia" },
                    { new Guid("7005bf2c-a806-43f5-ac54-0ddb531db5d6"), "Granada" },
                    { new Guid("edab4f09-85df-4d3a-9910-150373e71732"), "Ghana" },
                    { new Guid("d34dcf41-cdf8-4b82-a131-5b6e140e4b1d"), "Dinamarca" },
                    { new Guid("f2bf4309-2aa3-424e-8f21-ede1b9089f0a"), "Yibuti" },
                    { new Guid("f1be55ed-5fef-4a05-8d41-741814fc7e5e"), "Dominica" },
                    { new Guid("93abcfb7-a6e2-4722-9983-0e7002c653da"), "Ecuador" },
                    { new Guid("edecab8f-8d32-4dda-a3a4-998127d286cf"), "Egipto" },
                    { new Guid("8a13aa65-cb45-4b89-b31e-632d7c271117"), "El Salvador" },
                    { new Guid("d523c7d2-7c6f-4f5d-8616-113bcfe79f71"), "Emiratos Árabes Unidos" },
                    { new Guid("7215298e-8221-4c18-a585-510724de1b92"), "Eritrea" },
                    { new Guid("d76d823d-d00a-453a-9f59-163ed963fb3d"), "Eslovaquia" },
                    { new Guid("391843c5-4637-4e8f-85bd-d7774b2b502c"), "Eslovenia" },
                    { new Guid("af5fdc0b-9798-425d-91cf-b9e50545585f"), "España" },
                    { new Guid("2bbba4ab-ecdf-493a-950e-bd9af98ef704"), "Estados Unidos" },
                    { new Guid("b0106840-1627-4b26-b13e-b19168bed425"), "Estonia" },
                    { new Guid("d332ffb1-dccf-4200-b65c-3bbf53264067"), "Etiopía" },
                    { new Guid("73bc7b13-4a36-4d8a-81df-26b8e7c1a134"), "Fiyi" },
                    { new Guid("7b56cc5b-06ed-4d20-9039-0130cd2eb01b"), "Filipinas" },
                    { new Guid("f0f60003-7288-4775-9a31-fce8f6e1a5b0"), "Finlandia" },
                    { new Guid("51f7ce87-5494-425b-a8dc-4237fcb43410"), "Francia" },
                    { new Guid("fdad079d-671f-44fa-b928-b400e9451758"), "Gabón" },
                    { new Guid("5b7311ec-8753-47ac-a4fd-c7d93199c7ca"), "Gambia" },
                    { new Guid("9325cd46-3383-4773-b2a9-2bd0404fe258"), "Georgia" },
                    { new Guid("cffd239d-3250-4ab4-afbd-76be068a4444"), "Croacia" },
                    { new Guid("9ca2cc25-6ba3-423f-9944-eaa7f2b3e4a2"), "Zimbabue" }
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
