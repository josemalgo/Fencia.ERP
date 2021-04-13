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
                    { new Guid("97d4533b-c8a5-4450-9d43-864068bcf0c3"), "Afganistán" },
                    { new Guid("8765ea0c-232a-4e4c-ba9c-4a42c9525c51"), "Mozambique" },
                    { new Guid("826f8c36-6cb5-4bfd-9272-d9660b9a13c7"), "Birmania" },
                    { new Guid("3bf51dfa-cf8d-416e-93d8-561e62b16047"), "Namibia" },
                    { new Guid("50a7b36a-08d2-4fc1-a778-da540bedeaf0"), "Nauru" },
                    { new Guid("b489a0fc-d8ac-4cd8-b7e6-63637bd63eb2"), "Nepal" },
                    { new Guid("3fdf425b-2d92-45b2-80ff-fccfee3b2130"), "Nicaragua" },
                    { new Guid("ac59ca43-cc99-447d-9492-ca33886d7623"), "Níger" },
                    { new Guid("592e3870-937d-465f-a894-bc3696a16ff5"), "Nigeria" },
                    { new Guid("df164680-0cec-49bb-a1da-1e65f2e5ac00"), "Noruega" },
                    { new Guid("3fcab056-77b5-49fe-9164-9552563750db"), "Montenegro" },
                    { new Guid("3734e849-ec53-45f5-b470-740c7aa4702f"), "Nueva Zelanda" },
                    { new Guid("8e789420-c1b6-4dcf-8f22-ee1f8d80c0e4"), "Países Bajos" },
                    { new Guid("090d1d5b-2b55-4305-8dad-4f46e3792c5d"), "Pakistán" },
                    { new Guid("9dfda21f-0501-451d-8850-6ba0ff95306b"), "Palaos" },
                    { new Guid("cab80088-facd-4ca9-b57f-8c25c2816937"), "Panamá" },
                    { new Guid("58ad3f5d-1d2e-4ffa-81bd-9f2f73a80de7"), "Papúa Nueva Guinea" },
                    { new Guid("8b2be02d-4d35-4df9-a301-c4ac6f9f5d8b"), "Paraguay" },
                    { new Guid("d52cd213-77a3-48bf-90ae-1a62a1901531"), "Perú" },
                    { new Guid("0ae64ba3-8b6a-4d3f-afef-757616eea70e"), "Polonia" },
                    { new Guid("e256160e-dbef-4288-bd34-aec0ac056d44"), "Portugal" },
                    { new Guid("ff51e9d0-8894-4801-a4a6-5ece470fe76d"), "Omán" },
                    { new Guid("7b4574c9-f59e-4e82-92b1-e92c9f20ac44"), "Mongolia" },
                    { new Guid("b6354aff-b1b8-4d14-8f32-3a8307e78128"), "Mónaco" },
                    { new Guid("df876e7e-12d2-4b04-88f0-794eb96991b6"), "Moldavia" },
                    { new Guid("12a22c99-2f8e-4b9f-a6b2-d3403dac1278"), "Lesoto" },
                    { new Guid("f6054a30-73b5-4d7a-a458-2b57d0c3c3ef"), "Letonia" },
                    { new Guid("a76c9b98-e380-45b6-8456-bf855f1fd6d2"), "Líbano" },
                    { new Guid("ba8ccf04-f5d7-44b7-801c-cfa4f6095194"), "Liberia" },
                    { new Guid("afbfb669-c77b-462e-b55c-a557cf5c4ffc"), "Libia" },
                    { new Guid("ac04779a-f616-4688-9c59-f313400bf142"), "Liechtenstein" },
                    { new Guid("a34c44ab-7ca2-4a50-bb46-73fcf08febb2"), "Lituania" },
                    { new Guid("f609691e-7546-46dc-a572-4a4bdc85046c"), "Luxemburgo" },
                    { new Guid("5ff608b7-2602-4cf3-81c9-188e5ed29588"), "Macedonia" },
                    { new Guid("c2351853-d5f6-45ba-a4a2-24f50f3807b4"), "Madagascar" },
                    { new Guid("52099703-ee97-4134-be37-c0a30f3b6aed"), "Malasia" },
                    { new Guid("05b07132-2f81-47c5-9974-ab7ca659829d"), "Malaui" },
                    { new Guid("6f47d2d1-f5b7-4354-b237-2d6016906c9f"), "Maldivas" },
                    { new Guid("89cac102-aa54-405c-b51b-a7271fc722b1"), "Mali / Malí" },
                    { new Guid("006bff81-8775-476d-962e-baea4e6ab4cf"), "Malta" },
                    { new Guid("301fb53c-87e4-460b-92fa-39a2b0bc1bf4"), "Marruecos" },
                    { new Guid("ed3a93c9-39a3-4d56-9885-542ea6d0a2ae"), "Islas Marshall" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("58e0ac6d-f190-460b-8ac0-14e6889fae54"), "Mauricio" },
                    { new Guid("67681bbe-9131-4746-9c41-53b58ae37de1"), "Mauritania" },
                    { new Guid("c4c1c3cf-0c2a-45b2-b425-9acb2916432f"), "México" },
                    { new Guid("4278bd1b-329c-42d3-ae36-91d3cc28224a"), "Micronesia" },
                    { new Guid("9764cc0e-6b5e-4e47-b1d3-ff0a5e6aa771"), "Qatar" },
                    { new Guid("47b90428-901f-4faf-a7e0-dcbff2557304"), "Laos" },
                    { new Guid("af19b47a-e054-49e1-97b5-b1102b6a99e5"), "Reino Unido" },
                    { new Guid("e5cb6341-9684-4a8f-b523-331c2ea28908"), "República Dominicana" },
                    { new Guid("745b6555-d0bc-48c8-a10a-7afb26ba6e88"), "Suazilandia" },
                    { new Guid("0a8a9953-4fdb-4acc-97b6-861759bdc592"), "Tailandia" },
                    { new Guid("ef45eb28-0d42-4477-8f5a-fcd7e50a1ca2"), "Tanzania" },
                    { new Guid("61092099-9ca0-4b88-8c66-dbc7ea8af47f"), "Tayikistán" },
                    { new Guid("179a8783-e02a-40f6-b72c-43596f220be4"), "Timor Oriental" },
                    { new Guid("34a7a506-842b-4ae1-a6c5-b3966b78a77b"), "Togo" },
                    { new Guid("a55b2abd-d175-46f2-b468-f67996f9d530"), "Tonga" },
                    { new Guid("485072e0-e536-478b-8e8b-0dc5baa1b6c8"), "Trinidad y Tobago" },
                    { new Guid("59824205-537a-440b-9f9c-f1c34e1afdac"), "Túnez" },
                    { new Guid("70b961f8-a111-43f1-ba7d-2b58ce07b574"), "Surinam" },
                    { new Guid("69c143e0-0c86-4086-8707-e6e0a5e5cacf"), "Turkmenistán" },
                    { new Guid("f737ff09-4596-4544-ad34-296f5fa36777"), "Tuvalu" },
                    { new Guid("9d6ed9fb-68de-4d13-970b-7bc179308321"), "Ucrania" },
                    { new Guid("0b130dba-d30d-4220-8fc1-20abebc2349a"), "Uganda" },
                    { new Guid("479daf8a-0aa4-4d14-8ff5-bbe7936895a6"), "Uruguay" },
                    { new Guid("11622fca-0608-4f5a-a44c-d76a970b9d36"), "Uzbekistán" },
                    { new Guid("22523c5b-2cb6-49c5-9db0-bdfe91f8328d"), "Vanuatu" },
                    { new Guid("7151cf98-2d9e-4d75-bf5d-dec518d4daad"), "Venezuela" },
                    { new Guid("13d4e022-19a3-410c-9cf3-a9b0852898fe"), "Vietnam" },
                    { new Guid("b3a87936-f146-410f-9c4e-c251c3a33ec0"), "Yemen" },
                    { new Guid("ad5595bd-6142-479e-b892-be40bbd4d1b0"), "Turquía" },
                    { new Guid("a0d4c33e-6831-4f16-bd06-21e78a388405"), "Suiza" },
                    { new Guid("10601a68-92a8-4d2c-9043-3fb09af3ad87"), "Suecia" },
                    { new Guid("7bfcf654-c7cc-4863-b41a-d6d5f2190aef"), "Sudán del Sur" },
                    { new Guid("9d9b4812-c668-4c49-929d-87eb367c73a7"), "Rumanía / Rumania" },
                    { new Guid("1f0142f9-71df-483d-bcea-f6045bc78960"), "Rusia" },
                    { new Guid("cc33c331-b229-49e8-9eca-54464dd89c07"), "Ruanda" },
                    { new Guid("cf32388a-ecdb-4345-9ee3-5698e923a766"), "San Cristóbal y Nieves" },
                    { new Guid("fe92c0d1-6fcc-476a-9642-20cab3d13412"), "Islas Salomón" },
                    { new Guid("af13eda4-2d41-4641-ba1b-97ad4738ed43"), "Samoa" },
                    { new Guid("5a74468e-6593-46a0-89ca-073e7c662948"), "San Marino" },
                    { new Guid("95bc010f-d24d-4f34-aa76-24e9213322c4"), "Santa Lucía" },
                    { new Guid("0e41dedb-3496-4b9c-8950-e3089cfa0916"), "Ciudad del Vaticano" },
                    { new Guid("58e23c9f-0b83-4984-8a12-353274a2a2f0"), "Santo Tomé y Príncipe" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6e3685b7-a732-4687-a96e-1e54bf934314"), "San Vicente y las Granadinas" },
                    { new Guid("72a638cc-f314-4872-a4e4-fa6eda0d70f1"), "Senegal" },
                    { new Guid("455a6673-3305-4bb7-be6b-e8b68ed75ada"), "Serbia" },
                    { new Guid("ccae4c25-a8ee-44de-9a47-27e79402916e"), "Seychelles" },
                    { new Guid("d34a1a87-0bc0-4998-ae18-515e4b615428"), "Sierra Leona" },
                    { new Guid("34eb7482-d0c2-407c-a6ab-2d5f4eff6b21"), "Singapur" },
                    { new Guid("4601d095-08d9-4f7f-8102-48f4d3731866"), "Siria" },
                    { new Guid("2785d839-09bf-474e-a7bc-61a8067916a4"), "Somalia" },
                    { new Guid("c7352e50-1471-4aba-95de-78b464baf072"), "Sri Lanka" },
                    { new Guid("c2d1d74b-5e4b-44f6-8b59-a4cb668f1305"), "Sudáfrica" },
                    { new Guid("33308e75-ca1d-42c8-8fc9-84df823ef395"), "Sudán" },
                    { new Guid("ca90aa27-7f46-4140-bcd2-479a44af6f5c"), "República Centroafricana" },
                    { new Guid("2ac04d4a-31b9-4bd8-8536-abb4aac822db"), "Zambia" },
                    { new Guid("1a132eb7-2a0b-470b-8687-18e6ea8fc0f0"), "Kuwait" },
                    { new Guid("89c4002e-67f4-4094-9b96-e99732f1f4cc"), "Kirguistán" },
                    { new Guid("3767e496-953f-4b2b-916b-fa999d4aa9fc"), "Brunéi" },
                    { new Guid("3c246c38-65ee-436e-af42-bb4dc0df7935"), "Bulgaria" },
                    { new Guid("4ecdd520-ab8e-42b7-bb0d-01622edac9b5"), "Burkina Faso" },
                    { new Guid("3045c8ae-390b-4a3f-b70e-7aa6d94bac9c"), "Burundi" },
                    { new Guid("41ce878f-aafa-4806-a9e6-d60447440c3e"), "Cabo Verde" },
                    { new Guid("e52d3a38-a6e3-4498-8977-288a2bd8a7bd"), "Camboya" },
                    { new Guid("74e0ef7c-57ca-4156-97fc-2e6ebec69fdb"), "Camerún" },
                    { new Guid("9ce8753c-16bb-49ad-8117-77b762d7e5aa"), "Canadá" },
                    { new Guid("41c60e88-cdba-46fd-ab38-53c786d59b97"), "Chad" },
                    { new Guid("f73291f3-c96e-4092-9c2a-f88fe9bcce4c"), "Brasil" },
                    { new Guid("acb80233-5526-42f6-ad72-172bb5b59fee"), "República Checa" },
                    { new Guid("11c867ee-fa25-47ad-9cd1-0cc26656fa4e"), "Chile" },
                    { new Guid("a8cafc00-a1dc-4a3c-8652-858d7f701b72"), "China" },
                    { new Guid("f5717a33-924f-44d1-9632-c813d045d337"), "Chipre" },
                    { new Guid("4ac8ed17-5f7b-4fcf-b32e-217e0f1b5f68"), "Colombia" },
                    { new Guid("1f4af18e-55ce-4b24-9a33-43c94c4ead94"), "Comoras" },
                    { new Guid("ff14e5c3-b602-4c67-b5fb-681cea3ca98f"), "Congo" },
                    { new Guid("c06f3ce0-e7a0-40a6-b33c-3f9688623f5b"), "República Democrática del Congo" },
                    { new Guid("872c9271-3a52-4f1a-8d28-fc048c5d96cb"), "Corea del Norte" },
                    { new Guid("cd0c5966-49b0-4126-9332-df2d8e185fa7"), "Corea del Sur" },
                    { new Guid("318f8e62-d064-4923-bc62-af65fd8ce5e9"), "Chequia" },
                    { new Guid("e20e2db2-e92f-47dc-9a75-60e193d619b3"), "Botsuana" },
                    { new Guid("71be8f7b-adf8-4e62-8cdd-1852808dbfed"), "Bosnia-Herzegovina" },
                    { new Guid("4bff07a0-05e9-46ca-b5f6-073857909c24"), "Bolivia" },
                    { new Guid("2017f86d-ba97-440d-afdd-38e4ca466e81"), "Albania" },
                    { new Guid("42a532d1-04d9-493e-ad76-146c9c5b2fa4"), "Alemania" },
                    { new Guid("f4d21ae9-4fc6-465b-b40c-8a81fb5c910e"), "Andorra" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f87e153-96ab-4e1b-9376-b60a939d3ad6"), "Angola" },
                    { new Guid("0809f6df-8958-4aa4-bf11-e0bcb101834b"), "Antigua y Barbuda" },
                    { new Guid("19233a95-244d-4a0b-b70f-a008eed2067c"), "Arabia Saudita" },
                    { new Guid("8fa27636-b5b9-43ab-8153-25a8b2ef4a06"), "Argelia" },
                    { new Guid("80e6bdec-0e19-4f64-9af5-b44041ccd21d"), "Argentina" },
                    { new Guid("4a09fec8-a165-4cbb-89da-2d11001a7ae7"), "Armenia" },
                    { new Guid("d65a9393-5274-4889-be6a-f46af57f82b9"), "Australia" },
                    { new Guid("c24bb2f2-7549-46c7-ba0e-be14aebc1f5c"), "Austria" },
                    { new Guid("85446a3d-0185-4644-8262-c0bab4777943"), "Azerbaiyán" },
                    { new Guid("c7b06cd3-d98c-4992-a24e-76a1f8ad9641"), "Bahamas" },
                    { new Guid("357a1531-6e7a-4430-99ca-09a9ac4c4ed5"), "Bahréin" },
                    { new Guid("a81192b7-8a31-41ce-af3b-848c64c06979"), "Bangladés" },
                    { new Guid("eb4323c8-0e5c-4421-827e-bae8eeea2665"), "Barbados" },
                    { new Guid("caf644a8-cae8-4b4a-9a14-142de33870d0"), "Bielorrusia" },
                    { new Guid("2fa9498b-c1aa-403b-80ca-0418b90bb823"), "Bélgica" },
                    { new Guid("ab3a3497-0a71-43fd-9f83-cd53b3d7f04c"), "Belice" },
                    { new Guid("e6c401d9-38e0-4130-806e-dd29154279b2"), "Benín" },
                    { new Guid("44cafb85-0620-4c95-b581-58980b70c871"), "Bután" },
                    { new Guid("42db10cc-11f6-4bb3-b2a6-8e896a9513b7"), "Costa Rica" },
                    { new Guid("357d33f5-9f14-4fc7-877e-8865bab3ca15"), "Kiribati" },
                    { new Guid("e9ef079b-8717-43ef-8fff-7826b2023eca"), "Costa de Marfil" },
                    { new Guid("4a49e947-a176-4a9f-b43a-e79e1ab78e22"), "Cuba" },
                    { new Guid("2c184ad2-a154-4a9f-b5c5-23298ecd1007"), "Guinea" },
                    { new Guid("e6b359aa-a0ac-4860-9df9-d3c9f8722a4d"), "Guinea-Bissau" },
                    { new Guid("dcf5f633-ff72-448b-b888-7123d4d9734f"), "Guinea Ecuatorial" },
                    { new Guid("2e1e9917-3ff4-4133-b615-eb32765ae7ad"), "Guyana" },
                    { new Guid("a66528f3-a310-459a-9560-e7dfff5cc67b"), "Haití" },
                    { new Guid("1483194b-8aff-4586-afcd-35e3ecdef3fe"), "Honduras" },
                    { new Guid("e922382f-d93b-4565-bff5-8cca2bbe9d1f"), "Hungría" },
                    { new Guid("5f9ca932-5ffe-4568-9ba0-aea38e43e879"), "India" },
                    { new Guid("3187c21f-495d-476a-8ebf-06535f7d662a"), "Indonesia" },
                    { new Guid("65a621b4-b59d-4ffe-a599-040ff99132e1"), "Guatemala" },
                    { new Guid("2184f64e-0dae-4e89-9fd7-2f77b558a48a"), "Irán" },
                    { new Guid("7b1ea92a-f218-4a29-8d98-390aa7afe0bc"), "Irlanda" },
                    { new Guid("04953d2e-fe5e-4788-82a5-33dec8856160"), "Islandia" },
                    { new Guid("e2e618da-657a-4127-875d-f8f2fbb9d70f"), "Israel" },
                    { new Guid("45091f1c-e509-466d-8922-43b428cfcc77"), "Italia" },
                    { new Guid("0b898297-d275-4682-83b6-19c46352f318"), "Jamaica" },
                    { new Guid("dae95d22-8437-4594-9073-560dc2a5367b"), "Japón" },
                    { new Guid("aa2b39bc-aa51-4e45-8956-80826969b8b0"), "Jordania" },
                    { new Guid("fe1d9507-60d1-47aa-9030-128079cf2817"), "Kazajistán" },
                    { new Guid("43e7e98c-6f2d-4ec3-9343-96ded8c47d6f"), "Kenia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9b317850-eab2-4ef1-9727-f44285084533"), "Iraq" },
                    { new Guid("9d619bb3-7582-497f-92d2-7a66e21b0919"), "Grecia" },
                    { new Guid("87c0bc65-a158-4357-aa8b-732b20f80a00"), "Granada" },
                    { new Guid("4ca13528-6c5f-484f-985b-006dd8ba1ed9"), "Ghana" },
                    { new Guid("e6af949d-e03e-4fe9-a1a7-5d799dc9e778"), "Dinamarca" },
                    { new Guid("ffe867e6-ed82-4820-a87b-52ffa6de0b92"), "Yibuti" },
                    { new Guid("193da4df-10d8-439e-99c7-0db566519323"), "Dominica" },
                    { new Guid("b51247ab-4376-4c53-87de-29b01667effa"), "Ecuador" },
                    { new Guid("21746609-9a31-4750-9747-d00dcf8b8562"), "Egipto" },
                    { new Guid("70ce0bc9-803a-4fe9-b3a9-686a13c0864c"), "El Salvador" },
                    { new Guid("a34b712c-e0af-435f-b602-12408c529159"), "Emiratos Árabes Unidos" },
                    { new Guid("b2fe24cc-c15c-4d30-bc8a-cae3a6f72f58"), "Eritrea" },
                    { new Guid("33a945ac-a227-4b81-a88e-67b3707b5619"), "Eslovaquia" },
                    { new Guid("4a46ec15-8948-4cef-8e6c-9d13708e4d29"), "Eslovenia" },
                    { new Guid("d30c1810-98b3-47c5-9f54-a0ef87d49858"), "España" },
                    { new Guid("66607da3-f666-4304-8479-65d9c18db62e"), "Estados Unidos" },
                    { new Guid("b234b3c8-889b-4b26-9324-a6fe5903d677"), "Estonia" },
                    { new Guid("91ca5ebf-3ee5-4943-be46-887e12d326c1"), "Etiopía" },
                    { new Guid("174957cb-e7c2-4fa7-aa5c-2744f293f159"), "Fiyi" },
                    { new Guid("608d4c39-350d-4394-be0d-df33c4df7bc5"), "Filipinas" },
                    { new Guid("d766b754-6714-4f33-afc4-26ed81aa95af"), "Finlandia" },
                    { new Guid("2daac162-09f2-4bfe-8b7c-816cf22d2ebd"), "Francia" },
                    { new Guid("97f9997e-ee19-4fbf-a256-5037c4f3ded8"), "Gabón" },
                    { new Guid("ba7268f4-5eda-4811-b619-6b0acbdb4750"), "Gambia" },
                    { new Guid("b7f110b0-1612-4e4c-893c-5833a817109c"), "Georgia" },
                    { new Guid("86cabb94-106d-43b3-b516-cf618a924787"), "Croacia" },
                    { new Guid("137cd154-27b2-48f0-8f9a-77d8d622388b"), "Zimbabue" }
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
