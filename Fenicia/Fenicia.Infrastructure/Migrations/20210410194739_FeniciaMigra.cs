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
                    Iva = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                    TotalPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    NumberItems = table.Column<int>(type: "int", nullable: false),
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
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    { new Guid("c1342f40-a7b6-47bd-9189-acf619c97545"), "Afganistán" },
                    { new Guid("efa30cd2-e1eb-4464-bcb3-780367b3b3a9"), "Mozambique" },
                    { new Guid("cb6e337e-5c13-40c5-8644-6d84fa80b8d4"), "Birmania" },
                    { new Guid("c18eafd1-d718-42be-b4e7-f7957ce35af5"), "Namibia" },
                    { new Guid("22782a4e-4eef-48dd-bdfc-11e211780b15"), "Nauru" },
                    { new Guid("ec64c421-70ab-4f54-a85c-fb734856a39f"), "Nepal" },
                    { new Guid("09290e82-04cf-4d73-ab40-1499b7a15407"), "Nicaragua" },
                    { new Guid("f95e79e0-55b2-4e3a-8bbb-b25e3a8eba60"), "Níger" },
                    { new Guid("f1fef602-ca1d-4048-8fd7-04c93099fe63"), "Nigeria" },
                    { new Guid("50c19d6f-be89-4528-bd7b-5abd6b2faf24"), "Noruega" },
                    { new Guid("f18dec61-fd74-4356-9461-4c58548997e4"), "Montenegro" },
                    { new Guid("9c2486fa-ef4f-4da7-8fff-419b28841d90"), "Nueva Zelanda" },
                    { new Guid("214275cf-aa30-4b1a-842a-7e76ad311c13"), "Países Bajos" },
                    { new Guid("f8217bec-3e50-4c79-9751-10143ae9e735"), "Pakistán" },
                    { new Guid("afdc812e-ead3-4c27-8f04-175e23779588"), "Palaos" },
                    { new Guid("29df6755-8af5-4c9b-9292-104d122f607f"), "Panamá" },
                    { new Guid("e15bf30c-2f53-4ab5-99e1-826ddd17c3c2"), "Papúa Nueva Guinea" },
                    { new Guid("5ea06cb4-8baa-428c-8d5c-a2424f6d71b4"), "Paraguay" },
                    { new Guid("ce779625-5836-4e40-9bd5-9657702fc3b0"), "Perú" },
                    { new Guid("019065b4-e35c-47d9-99a9-1a1447989790"), "Polonia" },
                    { new Guid("8a6e15bf-d0f9-439a-9298-5911229adace"), "Portugal" },
                    { new Guid("400b3ca7-fe3b-4581-a721-fd2a6f92d682"), "Omán" },
                    { new Guid("3c443718-f4e6-4668-a22c-063d20a4815b"), "Mongolia" },
                    { new Guid("625a81e6-8c8e-4115-8dd3-8f9040abba8c"), "Mónaco" },
                    { new Guid("da75b499-db20-4dcb-9395-df9ea2baca33"), "Moldavia" },
                    { new Guid("5d2a3fe1-ced5-450b-8ea2-693228543445"), "Lesoto" },
                    { new Guid("8786d78f-0075-4fc3-88af-109e442d618f"), "Letonia" },
                    { new Guid("512bfabd-a709-4d56-8c93-26e745d6e226"), "Líbano" },
                    { new Guid("97f28e74-59e5-455b-bd74-ab659ff5a357"), "Liberia" },
                    { new Guid("4ceddccc-2d21-4d1e-a0f4-07d0609fbc66"), "Libia" },
                    { new Guid("2f3a452f-2563-47bc-b8eb-038d4dfef44b"), "Liechtenstein" },
                    { new Guid("e76f41ab-dd3f-4fa7-8ad9-1239c47d1d0b"), "Lituania" },
                    { new Guid("d4ace6c4-8f77-4c07-bec2-0fa85d735bb9"), "Luxemburgo" },
                    { new Guid("a542e7be-1dbc-4e94-b865-be73d958d21b"), "Macedonia" },
                    { new Guid("a6b48617-32ff-4ee4-9351-ad0bb1cd1279"), "Madagascar" },
                    { new Guid("8edd6643-9980-42fa-9c71-ccb0796ea630"), "Malasia" },
                    { new Guid("b64d3565-ed46-490b-8675-4e757bf37c69"), "Malaui" },
                    { new Guid("c11b1034-8991-4aac-ad5e-280c1867703e"), "Maldivas" },
                    { new Guid("b75500e9-6425-474c-a384-9d8591a80cb3"), "Mali / Malí" },
                    { new Guid("0fc15cdb-b3b1-4c18-9089-b4f5063ed761"), "Malta" },
                    { new Guid("814c92dc-022b-413a-9e30-529cea551e48"), "Marruecos" },
                    { new Guid("172f2f25-756e-4b83-a159-c3755a024c20"), "Islas Marshall" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14912512-9c3f-4499-9962-f30d83f0ea60"), "Mauricio" },
                    { new Guid("087234e2-d5d8-4681-88d5-c6bfe07162b7"), "Mauritania" },
                    { new Guid("c656a508-6aa0-4615-b656-3b776fdae1ae"), "México" },
                    { new Guid("210db976-d1c4-40c3-8b5c-95a9a100d54d"), "Micronesia" },
                    { new Guid("bcae80f2-bd15-497a-9b53-eb6601287dde"), "Qatar" },
                    { new Guid("57701f80-c39d-4e04-aa05-ab3d0fe27dad"), "Laos" },
                    { new Guid("955d782b-874f-49e2-9954-8a732be088be"), "Reino Unido" },
                    { new Guid("5a35643b-311d-4646-b070-df2cfd51a808"), "República Dominicana" },
                    { new Guid("8c052a0e-7eed-4002-809a-cf959ed409aa"), "Suazilandia" },
                    { new Guid("06b0ae7f-75bb-4566-a9f8-d4fb1846a01f"), "Tailandia" },
                    { new Guid("c2fd0274-7580-4734-bd6b-8125f749b16e"), "Tanzania" },
                    { new Guid("6400f540-ffd4-4f6c-928c-34c8941e8d1b"), "Tayikistán" },
                    { new Guid("dfa93433-8b25-499b-9a77-17f139027e8c"), "Timor Oriental" },
                    { new Guid("c35b7cf9-bab3-4f1a-b18f-d4cb304eb3d5"), "Togo" },
                    { new Guid("aaa731aa-de3c-4a79-aa29-76e2dd42b06a"), "Tonga" },
                    { new Guid("5e8b4184-3dc3-498a-926e-441c2443233a"), "Trinidad y Tobago" },
                    { new Guid("635c0515-877d-4107-bb74-35d727ba29f1"), "Túnez" },
                    { new Guid("f1ce0b25-b8a0-4db4-a9a2-c520c48d4e35"), "Surinam" },
                    { new Guid("93e1173f-7435-4390-ba58-c22f6ed34f5f"), "Turkmenistán" },
                    { new Guid("6d300f86-0ea8-4985-bd85-24f07f5aca29"), "Tuvalu" },
                    { new Guid("3a06246e-d66b-4878-b5bc-c80e7ecd07ad"), "Ucrania" },
                    { new Guid("730a4b90-9d77-401e-bada-50bd3335699b"), "Uganda" },
                    { new Guid("85482c08-c21d-4853-b3ef-f0a903cb6b33"), "Uruguay" },
                    { new Guid("b918f473-0bce-48de-8421-1f8fbc5490ba"), "Uzbekistán" },
                    { new Guid("9476ad2c-95a2-4bb4-875f-aad64431dee6"), "Vanuatu" },
                    { new Guid("de9ff169-eb41-43e6-9e58-ad7d8c36258b"), "Venezuela" },
                    { new Guid("e0ec2f5d-ccd8-48c2-93cb-e03b883359bb"), "Vietnam" },
                    { new Guid("fac2afdb-333c-4333-b770-864e18445acb"), "Yemen" },
                    { new Guid("8d7bf27f-7d45-419a-9df7-1abe6d5ef4ef"), "Turquía" },
                    { new Guid("4960827b-4cf7-4b8a-b0ea-11b0ba5ca61e"), "Suiza" },
                    { new Guid("331c4e37-0e68-4b63-a956-f0426bb60000"), "Suecia" },
                    { new Guid("05cbc3c6-f439-428f-84d6-3798ddc6ec82"), "Sudán del Sur" },
                    { new Guid("717e7a36-e3b6-4b4e-8a67-7a638c777721"), "Rumanía / Rumania" },
                    { new Guid("5546ab8c-f79f-4254-8403-589c905d529c"), "Rusia" },
                    { new Guid("b6261339-7118-463f-bb3a-abd968004842"), "Ruanda" },
                    { new Guid("a8f10f64-2112-4476-875b-f19ae7a9bf0a"), "San Cristóbal y Nieves" },
                    { new Guid("dfba2d29-298c-4cc1-b912-9187834973ba"), "Islas Salomón" },
                    { new Guid("5d4338f9-0f43-429c-9cff-2faa154155db"), "Samoa" },
                    { new Guid("c5567525-3fe6-4a0c-a263-e19b560dace1"), "San Marino" },
                    { new Guid("f5661aa0-3753-4758-9fd2-697536b2f55d"), "Santa Lucía" },
                    { new Guid("6f4c511a-050e-4778-be89-10fd24e37291"), "Ciudad del Vaticano" },
                    { new Guid("35ae1cdf-7fc4-4acf-aee9-f9d54b36b0b0"), "Santo Tomé y Príncipe" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("61ca4a3c-76a9-4da1-ad9c-7f5d2278df09"), "San Vicente y las Granadinas" },
                    { new Guid("42b83d90-43c6-4a67-8fbe-6fe2612b9cf7"), "Senegal" },
                    { new Guid("003349c9-cc4e-4283-b96c-c85a40365d6a"), "Serbia" },
                    { new Guid("920d7edf-5c19-4043-9d22-c91a487bfe22"), "Seychelles" },
                    { new Guid("bfa45570-fc9c-4eb2-a9c7-f106f63ab227"), "Sierra Leona" },
                    { new Guid("44d13672-9e8a-4467-b807-583115a72472"), "Singapur" },
                    { new Guid("6106412d-11af-4361-a5db-f5d133319206"), "Siria" },
                    { new Guid("ee3022de-9550-4d3b-9453-24efbd7eca3b"), "Somalia" },
                    { new Guid("3ffd8620-3313-40e0-8f79-04572d9303f6"), "Sri Lanka" },
                    { new Guid("95e664f1-8cec-421c-b028-a3bf6720601c"), "Sudáfrica" },
                    { new Guid("44759d98-a868-40e1-bb8a-25dea292e8f8"), "Sudán" },
                    { new Guid("eb8671f3-0cef-4439-a971-e6cf258dc3cf"), "República Centroafricana" },
                    { new Guid("38c0622c-6cbf-47bf-b9fb-67356febaa9b"), "Zambia" },
                    { new Guid("8182b70e-6b05-4c32-b0b5-122edb5db04f"), "Kuwait" },
                    { new Guid("45b5f5dd-725e-4b92-bf73-d253ebd714da"), "Kirguistán" },
                    { new Guid("8d438d39-64ab-42d7-8704-b54478d45ab0"), "Brunéi" },
                    { new Guid("c69e1927-2227-4065-8222-508b3d15ee32"), "Bulgaria" },
                    { new Guid("b354a51e-803c-4fab-b8a0-4089c16b0f8e"), "Burkina Faso" },
                    { new Guid("f47494ea-4ded-4428-9932-3192e5649daa"), "Burundi" },
                    { new Guid("30c4b67a-1101-405e-a8da-fe4725521bea"), "Cabo Verde" },
                    { new Guid("7e739335-1cf8-4d25-a620-a8a5acc9b7b9"), "Camboya" },
                    { new Guid("aa4e84f2-a9ef-4fc0-b8ee-fb1e4cc99e03"), "Camerún" },
                    { new Guid("73a6b646-23c1-4814-a989-7b60ac11f28d"), "Canadá" },
                    { new Guid("f78278a8-5b0f-4337-ae14-f759df3662ac"), "Chad" },
                    { new Guid("a2561f8c-eef2-4ea3-bf49-bd8aa391eec3"), "Brasil" },
                    { new Guid("bad8d039-39f8-4026-a9ca-4ed993cbb13a"), "República Checa" },
                    { new Guid("bc8588d8-a460-4f43-9eba-4bccd2973fc3"), "Chile" },
                    { new Guid("eb4f5bfe-c34e-4472-b377-66d1d635a91d"), "China" },
                    { new Guid("6dfd214d-d4e5-4185-aa90-d64bc1051413"), "Chipre" },
                    { new Guid("0dcf9174-5f69-46cb-ba98-faa3fbb7f955"), "Colombia" },
                    { new Guid("1b210950-aac9-46d4-b96f-0a322b9d381a"), "Comoras" },
                    { new Guid("bce4c838-2a3d-4662-b096-830ee2ba2e13"), "Congo" },
                    { new Guid("b421fb21-e290-4a0b-9ef0-49d6af57eae8"), "República Democrática del Congo" },
                    { new Guid("1cbaae56-fd91-4997-bacd-aa7597bab888"), "Corea del Norte" },
                    { new Guid("45b3c6bb-b509-44d6-b1dc-4010f9d6d95d"), "Corea del Sur" },
                    { new Guid("ee7bf51b-2b26-4d9b-b41e-6afb3bacea55"), "Chequia" },
                    { new Guid("af0a8869-03b0-43cf-8745-d1d062da518d"), "Botsuana" },
                    { new Guid("7aa4be8c-cdbf-4bab-98fa-ec49553468ae"), "Bosnia-Herzegovina" },
                    { new Guid("8321f44c-1cb9-4551-9b89-71222784e6d7"), "Bolivia" },
                    { new Guid("9f5cf37f-43ef-47a9-9a43-f27b1379da61"), "Albania" },
                    { new Guid("02558442-b151-40fd-a174-e24f730914e6"), "Alemania" },
                    { new Guid("e5684620-4d14-4c31-8183-289aa66dc7dc"), "Andorra" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f8ccfa42-267f-4912-a2ed-bb8f291028c4"), "Angola" },
                    { new Guid("952e6417-20bb-45e4-99df-9ff7512c967f"), "Antigua y Barbuda" },
                    { new Guid("3638665f-ca68-4130-86cf-2bbd8f0f23e9"), "Arabia Saudita" },
                    { new Guid("6cfd2c99-8b1e-41b5-8dd7-9a7985ddbb0b"), "Argelia" },
                    { new Guid("1d0d50c1-a2fc-4dc3-965d-a5c2ad798370"), "Argentina" },
                    { new Guid("d0f3e01d-a32a-40a9-af03-b745d7fe0a83"), "Armenia" },
                    { new Guid("621cd71b-1494-4d5e-9268-55ed89cc825f"), "Australia" },
                    { new Guid("a39c82ff-5ba7-4709-a2ee-f7b9569deff1"), "Austria" },
                    { new Guid("48b981bc-dca3-4fb5-810f-0cbccdc223e9"), "Azerbaiyán" },
                    { new Guid("e0d338b8-c6e7-4745-9551-8dc2aed0682f"), "Bahamas" },
                    { new Guid("f5bbe03b-9df3-488f-9eaa-a3a80078efc2"), "Bahréin" },
                    { new Guid("4e1e7010-0c73-4b90-9517-84d280b34e23"), "Bangladés" },
                    { new Guid("6cd71326-0bcd-4b81-9545-c51e2ba46d87"), "Barbados" },
                    { new Guid("5f4c2942-6932-4def-ae1b-98dc5a08b313"), "Bielorrusia" },
                    { new Guid("67735363-36c5-48bf-bfcf-b5f38ee88fdb"), "Bélgica" },
                    { new Guid("27709fc9-4eef-4f6a-b155-b8e0bc7a327c"), "Belice" },
                    { new Guid("d715ce6f-3299-4af1-aeaf-665d960ddfb9"), "Benín" },
                    { new Guid("79921f91-4ae4-4e52-9b5a-acbd19112f8c"), "Bután" },
                    { new Guid("ff2479b4-56cb-4b3b-9d51-beddaccee8b7"), "Costa Rica" },
                    { new Guid("cc568911-a762-4e97-80f5-9d29e735c0a0"), "Kiribati" },
                    { new Guid("42f6a69a-d826-4b33-a4a2-d362ae5612ef"), "Costa de Marfil" },
                    { new Guid("0d4cf6a3-1b57-4928-9cdc-ee04e0e05bc7"), "Cuba" },
                    { new Guid("2c622981-3aa4-4e0b-8aef-e48dc64762d1"), "Guinea" },
                    { new Guid("5639c0e9-6f60-40cb-bf2b-9c6ed6723a5d"), "Guinea-Bissau" },
                    { new Guid("060b1e5e-6eac-48a7-a3e3-16f33adc8fee"), "Guinea Ecuatorial" },
                    { new Guid("a3cab066-db41-4ad6-a894-e0acff466819"), "Guyana" },
                    { new Guid("2ec6c08a-53f7-4721-aa48-d5503b9f0718"), "Haití" },
                    { new Guid("d9368b23-d8da-4b82-8c19-f82ba2e056df"), "Honduras" },
                    { new Guid("73dc978f-bb27-4304-a21c-7d2f5e5d4759"), "Hungría" },
                    { new Guid("65ff4ee5-1351-4180-9fc6-84961ec6fd28"), "India" },
                    { new Guid("d1d702ef-e144-4954-bb84-53e85ce8f775"), "Indonesia" },
                    { new Guid("ebe2842b-7c7b-48e7-8e61-befbcf23358a"), "Guatemala" },
                    { new Guid("6025cfed-8947-4974-9369-96623f8e8ef6"), "Irán" },
                    { new Guid("80ece93c-ed98-49df-972f-3c5ae3a1276f"), "Irlanda" },
                    { new Guid("48d22077-0abf-4242-9559-5533ec64cdca"), "Islandia" },
                    { new Guid("054c81a3-ce01-4e6e-8428-a46ede791d3e"), "Israel" },
                    { new Guid("10c69b72-9954-49d5-9153-c4527605bd4a"), "Italia" },
                    { new Guid("577a758a-6170-40d8-8a11-fe436a72a1df"), "Jamaica" },
                    { new Guid("edde2470-367b-4e4e-9e19-dbced62c78ea"), "Japón" },
                    { new Guid("d3e91207-e6ad-4b17-bb2a-ce45788b0c1f"), "Jordania" },
                    { new Guid("9d39a9ec-3d1c-419b-9b49-b3e6efca9924"), "Kazajistán" },
                    { new Guid("0999a7e6-fa9f-432f-ada9-a4cfba20c3b0"), "Kenia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b808026-b9d2-430a-8a29-cdd760029a17"), "Iraq" },
                    { new Guid("b3944b38-e845-49a0-9557-eac03f9cde79"), "Grecia" },
                    { new Guid("fc5acbc7-ed0b-42de-bc7a-352585305e21"), "Granada" },
                    { new Guid("498bff17-41dd-4acc-a6d6-d45005c3bc75"), "Ghana" },
                    { new Guid("057be884-2abf-4fa7-aa77-bac776a87c5b"), "Dinamarca" },
                    { new Guid("b5cf2399-8b10-4880-8e2e-363deaa62650"), "Yibuti" },
                    { new Guid("86846016-01b6-4cf4-9451-9571d57f993f"), "Dominica" },
                    { new Guid("d8a15ddf-66ce-455f-b8cc-28c4d0ac97a6"), "Ecuador" },
                    { new Guid("6e799d6f-06df-4506-9809-720ac446d2a6"), "Egipto" },
                    { new Guid("5a16ba1d-19bb-42f8-b351-841d18b3d82c"), "El Salvador" },
                    { new Guid("a232884d-2100-43a5-ba9f-a9cacb8b9a98"), "Emiratos Árabes Unidos" },
                    { new Guid("47acdd84-0418-4a44-b3f3-840f790a3d92"), "Eritrea" },
                    { new Guid("0b2a6222-6099-4d27-88e8-e8d2be96da02"), "Eslovaquia" },
                    { new Guid("c9d8f3eb-ab60-401d-bd12-9523bad7bdba"), "Eslovenia" },
                    { new Guid("ff827a8e-9524-4cbe-a995-e86becb9bfda"), "España" },
                    { new Guid("35875578-e7ad-48a9-8c52-72bde77e0d6e"), "Estados Unidos" },
                    { new Guid("2b7d3c75-8aee-4f5e-922d-bac6a859aa21"), "Estonia" },
                    { new Guid("00c01e08-6538-4574-8c7d-a059b33eb5e4"), "Etiopía" },
                    { new Guid("8e0831dc-a7ac-4c71-876c-cd8ca04515a2"), "Fiyi" },
                    { new Guid("965ec973-356b-4c1d-a8b3-4052184d91c0"), "Filipinas" },
                    { new Guid("8fb32fc3-1a76-459b-9c45-6376a84a47cc"), "Finlandia" },
                    { new Guid("1d763fc2-d665-43b4-a311-4bbf1b8275a5"), "Francia" },
                    { new Guid("bf9fa9fd-c3cf-41b1-b30e-78ad2f55f2f9"), "Gabón" },
                    { new Guid("d43c4c73-0b61-4073-83f2-897352e515ef"), "Gambia" },
                    { new Guid("1c4fdccb-22eb-493c-bd43-f8293af0cff2"), "Georgia" },
                    { new Guid("84476296-6ea4-41b2-8c5e-d31eb0387438"), "Croacia" },
                    { new Guid("91f3e528-8550-4bee-a1a3-0617d2b057ea"), "Zimbabue" }
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
