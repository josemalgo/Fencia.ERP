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
                    { new Guid("2f290f2e-ee39-4efe-a75d-4d12ef935dfd"), "Afganistán" },
                    { new Guid("1c4b47f8-a169-4157-b28e-f2a5c461096a"), "Mozambique" },
                    { new Guid("edeeab28-6b9b-4fef-b29e-63b1ffd11c54"), "Birmania" },
                    { new Guid("01d899a9-fe7a-45d0-a8c0-9a27b3b37cd8"), "Namibia" },
                    { new Guid("98a60156-6b13-4534-aee1-42d58b5cdda1"), "Nauru" },
                    { new Guid("3ab469d6-6a9f-49e6-a451-a2806ee25f4b"), "Nepal" },
                    { new Guid("ce3f0bd2-1146-48b1-a100-cc8fb7a75ccc"), "Nicaragua" },
                    { new Guid("9c5cc390-0206-4ccc-bf33-cee5d3ea6f1a"), "Níger" },
                    { new Guid("8c10dd89-6716-4a7f-8c0a-32d0c04de585"), "Nigeria" },
                    { new Guid("297bd061-d156-408a-8b26-89e872d11126"), "Noruega" },
                    { new Guid("719b5eb5-fa71-4806-be0f-83a0fb80ee5a"), "Montenegro" },
                    { new Guid("ca3fa539-1f76-466b-baff-6fe07ca658aa"), "Nueva Zelanda" },
                    { new Guid("33709068-9b3e-4b5b-865f-7b8f5775bef2"), "Países Bajos" },
                    { new Guid("2b92c850-4684-4c35-b5f7-6d679b8eeb6f"), "Pakistán" },
                    { new Guid("65d6b95f-2610-457d-8d95-334a1f5cb35b"), "Palaos" },
                    { new Guid("26b6876c-8359-4e8a-8983-49856accd4e1"), "Panamá" },
                    { new Guid("93aadefd-ca85-4aff-bbef-6e275578f5f5"), "Papúa Nueva Guinea" },
                    { new Guid("6f6919fe-02c4-41bd-935d-38d15d22ffa5"), "Paraguay" },
                    { new Guid("847f9be6-e744-49da-b8d4-e3becf427fa0"), "Perú" },
                    { new Guid("ec44a723-fddc-4a38-87d4-4375b1d4254f"), "Polonia" },
                    { new Guid("18226686-e7f0-434c-8b2c-899e80996233"), "Portugal" },
                    { new Guid("93c4ab31-6261-489f-8cbb-3c6b483e5098"), "Omán" },
                    { new Guid("19966756-fe26-4ca6-9db6-b3b553cb0fbc"), "Mongolia" },
                    { new Guid("f0ee7dcf-ae5b-4284-af81-8c698559ea98"), "Mónaco" },
                    { new Guid("dc776019-8fc3-4cff-8b28-9030b7e2d1c9"), "Moldavia" },
                    { new Guid("99e101de-2432-4702-9325-107f5b68fec0"), "Lesoto" },
                    { new Guid("1110e456-7c96-4a2a-9f8d-074a91267c94"), "Letonia" },
                    { new Guid("a6d47265-8b07-49c4-af2d-2841383e1250"), "Líbano" },
                    { new Guid("20edbe5e-30fb-49f9-bba8-5a072187b1af"), "Liberia" },
                    { new Guid("0217a6d2-f6cb-4525-b529-d64945228e75"), "Libia" },
                    { new Guid("3b7d8fc1-bff5-4c45-884a-9ba49465cc81"), "Liechtenstein" },
                    { new Guid("79eae639-d74e-4abe-ac3d-50037aa9aa12"), "Lituania" },
                    { new Guid("aaf839b9-96d5-4ae7-bdd8-a117ea8448af"), "Luxemburgo" },
                    { new Guid("1fc2213d-4eed-4a53-9117-c98d849fb43a"), "Macedonia" },
                    { new Guid("372b648e-1a89-4e36-9eb6-20fe94f52c0b"), "Madagascar" },
                    { new Guid("6ef75972-ab35-449a-a554-c03e5e5d21a3"), "Malasia" },
                    { new Guid("291419d4-58b2-40ae-a468-a80f569c91bf"), "Malaui" },
                    { new Guid("43ab63ce-632a-45d9-9632-db57963cf6f8"), "Maldivas" },
                    { new Guid("4c9d8c08-b4e6-462f-a9ee-b9d708623fb9"), "Mali / Malí" },
                    { new Guid("05a33b5c-8b64-481c-97c9-1e78e2e24cee"), "Malta" },
                    { new Guid("de342627-f4d0-4346-a642-4aca1167d405"), "Marruecos" },
                    { new Guid("23758763-ab9e-449e-95f4-247eac524853"), "Islas Marshall" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("48c9dcbf-e769-4372-a814-d84af3618495"), "Mauricio" },
                    { new Guid("1be6648a-268d-4b57-b6e1-38a7696a72a9"), "Mauritania" },
                    { new Guid("a75a2a11-0cf9-4f72-81f3-c0b344aec9b4"), "México" },
                    { new Guid("9f9b2872-20a5-4b1a-b063-92de71f701be"), "Micronesia" },
                    { new Guid("62a8f0db-5d63-407e-9f9d-240ecb9ff970"), "Qatar" },
                    { new Guid("e7eb6da0-7f0d-4188-9acf-c48b3b42e029"), "Laos" },
                    { new Guid("b63fb587-9775-4614-9da9-9dfa8674f676"), "Reino Unido" },
                    { new Guid("f5b47ad6-3652-4ee2-9a82-44d51c46ef53"), "República Dominicana" },
                    { new Guid("fe57dbe6-6570-473e-802e-8f87f8fa1f03"), "Suazilandia" },
                    { new Guid("d2128a05-d153-4a1a-a5ed-cc24d229829f"), "Tailandia" },
                    { new Guid("34dacfa9-d81d-4a09-a79e-e0895a5cd956"), "Tanzania" },
                    { new Guid("86b3ab77-1cc0-484b-a6e7-f0ab1cbce26c"), "Tayikistán" },
                    { new Guid("f57711a3-cdcf-4a5f-a3ec-e675b0bab6a7"), "Timor Oriental" },
                    { new Guid("221c97dd-9ada-41a9-8cdd-c2739e31dacc"), "Togo" },
                    { new Guid("d1a5eece-c429-4bdb-9f25-b4fc7592a90b"), "Tonga" },
                    { new Guid("4c963825-45e9-4efc-97e6-f11199c3a3e7"), "Trinidad y Tobago" },
                    { new Guid("4af6ff17-7104-4bf4-acfc-96fc68fd7ba7"), "Túnez" },
                    { new Guid("9838ec71-a5ca-4781-8830-283e7b72b8b4"), "Surinam" },
                    { new Guid("5b4ac238-00eb-42a9-8ad2-34590f35fe4f"), "Turkmenistán" },
                    { new Guid("367eb7b9-e456-4425-979b-9b87b39d2a63"), "Tuvalu" },
                    { new Guid("496ac1ae-9412-4f2f-83cb-4a894d63bf76"), "Ucrania" },
                    { new Guid("48a5a56f-b431-4866-9721-1c624b00acbc"), "Uganda" },
                    { new Guid("050363c4-0141-4aa4-8525-3c58bb3d5c42"), "Uruguay" },
                    { new Guid("d71361e2-0eb9-49a2-9fea-d09220c14a7d"), "Uzbekistán" },
                    { new Guid("d1ea0a1d-dabd-4654-9a67-bf64a5109d43"), "Vanuatu" },
                    { new Guid("c198c562-fc15-489c-bbab-a9b377052f0e"), "Venezuela" },
                    { new Guid("b7ef1759-0ee0-457e-ba7f-80a7f96b0312"), "Vietnam" },
                    { new Guid("de149bf1-41bc-4171-8306-d274c482c5cc"), "Yemen" },
                    { new Guid("ac6b10c1-08eb-4993-8433-213e1653d64f"), "Turquía" },
                    { new Guid("0421daae-7f4b-4cbf-9c58-3df233c20589"), "Suiza" },
                    { new Guid("fda070f5-d9bc-4895-9a32-8b988682b1a0"), "Suecia" },
                    { new Guid("ce93ed9b-9f2f-4641-b713-2c61a747b7bd"), "Sudán del Sur" },
                    { new Guid("06f086fe-c8e6-4390-adbf-b542d20cd5f3"), "Rumanía / Rumania" },
                    { new Guid("0c24f97f-67a3-4a7a-a855-9ccc477f2b22"), "Rusia" },
                    { new Guid("2789c802-c2e0-4ce0-b5a2-157a861b2907"), "Ruanda" },
                    { new Guid("bef09830-2403-4009-98a1-fa2c4f715fac"), "San Cristóbal y Nieves" },
                    { new Guid("72cffbc1-dfab-40ed-9b89-924b7e5d57e1"), "Islas Salomón" },
                    { new Guid("30fb2e2a-7cf2-4230-a778-78ee1b341029"), "Samoa" },
                    { new Guid("2a2b5e4e-162f-4a03-90e2-7ea6d79c8ce5"), "San Marino" },
                    { new Guid("20665036-e4d3-4955-b78a-b51abaa950d9"), "Santa Lucía" },
                    { new Guid("39af036f-7d9b-466d-94d6-9d9026403a21"), "Ciudad del Vaticano" },
                    { new Guid("841b05b7-9bc3-46dc-a19d-380b07feb7d9"), "Santo Tomé y Príncipe" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8902d9cd-fc54-4568-8e9f-97ee37b99c4a"), "San Vicente y las Granadinas" },
                    { new Guid("8a9cc037-acf8-4d13-b7e5-5eecc93245e1"), "Senegal" },
                    { new Guid("77c1997c-9ced-4d47-8070-56a8e7b357c5"), "Serbia" },
                    { new Guid("d4664451-03c3-4e49-9ab6-b4457535f78d"), "Seychelles" },
                    { new Guid("2bc92a15-4bba-422a-9ccb-a9dc6bb29982"), "Sierra Leona" },
                    { new Guid("a6af7578-ad77-4bd8-9b7b-2b9a429f6e3a"), "Singapur" },
                    { new Guid("f755a905-4afd-4b53-8384-31db4fa75622"), "Siria" },
                    { new Guid("84d71f37-e00d-4259-b120-902adad5cebb"), "Somalia" },
                    { new Guid("4b939543-ff33-4bf1-b763-b61a5a4b01df"), "Sri Lanka" },
                    { new Guid("4de98417-64c5-4e62-92f7-02ef471183d5"), "Sudáfrica" },
                    { new Guid("bb846f34-a43b-4682-906c-3cd0725c1dab"), "Sudán" },
                    { new Guid("77d3ec54-1148-4560-a0aa-1e792d60fcef"), "República Centroafricana" },
                    { new Guid("416a765c-78be-4aa2-a1fd-aaf3c6b7e604"), "Zambia" },
                    { new Guid("1803af95-a837-4fd0-9715-381c21eddb48"), "Kuwait" },
                    { new Guid("5c313659-6d3f-4dc4-937c-3c63684397fe"), "Kirguistán" },
                    { new Guid("5174a963-1ace-441f-bce5-96f781a79e6a"), "Brunéi" },
                    { new Guid("c72ea941-14fc-4819-9449-1c3b13ed85d9"), "Bulgaria" },
                    { new Guid("e4f8bfd0-19d0-4497-88da-84401b18efaf"), "Burkina Faso" },
                    { new Guid("01ad46b6-af41-493e-af85-ac29634ecf57"), "Burundi" },
                    { new Guid("84b8a5a9-31a0-420d-8064-4905d81d5300"), "Cabo Verde" },
                    { new Guid("3386723f-6887-480a-914d-7ac8efc6b4f5"), "Camboya" },
                    { new Guid("f4f59091-9406-4939-94ec-388a2912b098"), "Camerún" },
                    { new Guid("59137e19-7248-464d-8893-48b920982919"), "Canadá" },
                    { new Guid("4fdf69ff-6285-4e92-ad23-f7d1d21d3336"), "Chad" },
                    { new Guid("4cce342b-20ae-4305-9ee0-e9c2ae796cb0"), "Brasil" },
                    { new Guid("b1a56145-168f-461c-a195-48a6db7cfb34"), "República Checa" },
                    { new Guid("e12b476f-3727-4819-8483-d3cdcaa3619d"), "Chile" },
                    { new Guid("7c71b96b-feb3-44f3-bfa7-e31eea4214c6"), "China" },
                    { new Guid("69971625-f3ae-4f95-9829-9f9f55ee8920"), "Chipre" },
                    { new Guid("654c1365-f782-45aa-ad16-c6cffe778e0d"), "Colombia" },
                    { new Guid("0e003164-7b9f-4023-b8e3-f6133e921e19"), "Comoras" },
                    { new Guid("914c0810-f48c-414c-aab7-6521cd764a97"), "Congo" },
                    { new Guid("12b6c673-2b4d-4eae-acef-4c313cae6522"), "República Democrática del Congo" },
                    { new Guid("152afc6f-7349-450e-99a8-0844a2a5519c"), "Corea del Norte" },
                    { new Guid("ff792f96-8db1-410e-96ab-cd5b26aa4590"), "Corea del Sur" },
                    { new Guid("396058a6-68b3-41fb-a681-b100c4b129e8"), "Chequia" },
                    { new Guid("e35e2db6-174f-42e2-890d-a42b749d2865"), "Botsuana" },
                    { new Guid("66802337-4f1f-4308-9bd6-3e6e24890043"), "Bosnia-Herzegovina" },
                    { new Guid("d00de303-a427-4dba-99e3-ce7785327afa"), "Bolivia" },
                    { new Guid("5ef6939b-d84c-4a66-ad50-7b6687299670"), "Albania" },
                    { new Guid("f452fc25-651e-4659-a832-8a65fc10b68f"), "Alemania" },
                    { new Guid("5b71a090-8e26-451c-9ad1-86a041c7f18b"), "Andorra" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d3416a25-4d85-4c7a-8961-07ed3ddf5637"), "Angola" },
                    { new Guid("c343dd91-f2ad-443c-85d6-e088ec33b107"), "Antigua y Barbuda" },
                    { new Guid("0927fa82-99bb-4a83-9010-a22c5dce2c69"), "Arabia Saudita" },
                    { new Guid("eec80ce3-a175-40db-bca3-3e1975d6877a"), "Argelia" },
                    { new Guid("6048ce08-3cfb-4021-bc30-4a09eb2f63a4"), "Argentina" },
                    { new Guid("969b0951-ea0b-4aa1-b545-bc9cbcf189b3"), "Armenia" },
                    { new Guid("b96aec12-bf1d-4e9c-8552-c76f54e412a5"), "Australia" },
                    { new Guid("0e865cc9-8ac7-495d-97f6-b46e45a254e2"), "Austria" },
                    { new Guid("a1f5d348-942b-475d-92ca-cea307888c75"), "Azerbaiyán" },
                    { new Guid("76c6d848-af07-465e-b171-ce50ebde024e"), "Bahamas" },
                    { new Guid("01881b2d-b4b4-4637-aae1-2d6473888ae3"), "Bahréin" },
                    { new Guid("c933f23a-bf0e-4742-bdda-2948e1509a2b"), "Bangladés" },
                    { new Guid("64c4e5b2-60ae-4ecd-b25e-38a357a38043"), "Barbados" },
                    { new Guid("4e3a8fb5-f552-48f0-b711-63aaa5740042"), "Bielorrusia" },
                    { new Guid("c5de3a43-d9d3-4b87-9d4e-1a8ab3f70b81"), "Bélgica" },
                    { new Guid("961f3ada-8549-421c-ab2e-229a42ee7ae9"), "Belice" },
                    { new Guid("24322eb4-b411-4775-8c22-2a3b9a123479"), "Benín" },
                    { new Guid("59446476-1e6d-4ae7-b7fd-a87ad0f26787"), "Bután" },
                    { new Guid("d0ab88d6-9075-4c01-91a8-cfed97153f10"), "Costa Rica" },
                    { new Guid("53c80cb8-f6e9-4eac-8e61-88804952efaa"), "Kiribati" },
                    { new Guid("30a7fe91-0147-4941-b9cd-c5f9e6e94815"), "Costa de Marfil" },
                    { new Guid("790b7572-ca7f-4109-96c7-ad4383107c53"), "Cuba" },
                    { new Guid("bd99a00b-959a-4aa7-96bf-abdb0025fee3"), "Guinea" },
                    { new Guid("aad057cc-d4cc-4803-8ae3-c6e251fd126a"), "Guinea-Bissau" },
                    { new Guid("db8bd69c-5318-45cc-a467-19cefafe13e8"), "Guinea Ecuatorial" },
                    { new Guid("e521ed68-2a66-4b4d-aed8-5a0368a7fd5f"), "Guyana" },
                    { new Guid("31b8d85f-73e2-40e2-bea6-8e202fce7c12"), "Haití" },
                    { new Guid("ff8338f8-d58b-4e56-aa7c-65a6e5333a24"), "Honduras" },
                    { new Guid("78805076-ee7b-492c-913e-4211103508d0"), "Hungría" },
                    { new Guid("effd856e-0210-42a3-ac58-dc4c9322d7c9"), "India" },
                    { new Guid("362749c2-b515-4290-890f-104a111a8ecd"), "Indonesia" },
                    { new Guid("f1161fde-e21a-4ebe-8640-153f966c4143"), "Guatemala" },
                    { new Guid("a1bc0760-1581-43b2-ad82-e641bf6b73a3"), "Irán" },
                    { new Guid("bc7ef60e-0f37-4709-bfd9-d999ca39b87d"), "Irlanda" },
                    { new Guid("edb8e03b-b432-4829-b486-c43b2864e8d1"), "Islandia" },
                    { new Guid("729686cd-a640-4d35-838f-999ae9672f0d"), "Israel" },
                    { new Guid("69018e48-b709-4c07-96f8-ffb847671650"), "Italia" },
                    { new Guid("9ee25a63-1694-4ec3-b36d-c33101a37bb7"), "Jamaica" },
                    { new Guid("d9e0c35f-4eb6-4f3c-aff9-adfc90aba8ac"), "Japón" },
                    { new Guid("a4a9cb5a-09bc-448b-a9d7-3e4313f58b34"), "Jordania" },
                    { new Guid("be3a5dab-c99f-4ab7-bf21-502189b3cd07"), "Kazajistán" },
                    { new Guid("c3fc549f-eaef-4804-a557-348d2a6f78f2"), "Kenia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("558a82aa-e74c-427b-8b89-f6c9e3ab46db"), "Iraq" },
                    { new Guid("a8abcc62-8754-4d12-aeba-6fd606d445a7"), "Grecia" },
                    { new Guid("2b540ac6-f84c-475b-b7a5-221b5e0f6dfb"), "Granada" },
                    { new Guid("9fae55d1-10b5-4a87-9c88-93f58f8e1e45"), "Ghana" },
                    { new Guid("9bc6b26c-233b-48a4-b6cc-c5ba074410af"), "Dinamarca" },
                    { new Guid("32cb9dd7-00e1-4a7d-8112-c887e65ec6a4"), "Yibuti" },
                    { new Guid("66acc29a-6aa2-468f-9378-762ce8d4c160"), "Dominica" },
                    { new Guid("4efc9a3c-3672-449c-b91e-f00ea156c275"), "Ecuador" },
                    { new Guid("ede00d18-4cb7-453d-9583-a949fc70154c"), "Egipto" },
                    { new Guid("554627f9-f176-4be2-a34e-a63337d0cdc4"), "El Salvador" },
                    { new Guid("1be1c513-084e-4ce7-bbeb-ba6edf61738b"), "Emiratos Árabes Unidos" },
                    { new Guid("30d5fd18-3ca6-4148-9f48-f8d79651b216"), "Eritrea" },
                    { new Guid("1baf6c83-a320-4c89-8422-b56d90f0a55e"), "Eslovaquia" },
                    { new Guid("75ff7e6e-ab4c-4f72-9d43-5da9c4690f86"), "Eslovenia" },
                    { new Guid("ff67c964-99a3-44de-97ee-63fc7f37e541"), "España" },
                    { new Guid("d77564e1-d9f2-4d2d-addc-3d65dde8bc41"), "Estados Unidos" },
                    { new Guid("07d78e8f-5199-46e7-833e-7dd7fb11c84e"), "Estonia" },
                    { new Guid("31b794f9-98fa-44ed-88eb-ed2f77347478"), "Etiopía" },
                    { new Guid("342887c6-1966-4996-8f63-79fbe33be904"), "Fiyi" },
                    { new Guid("d34d7d98-a682-4b7f-ac99-92bee0457966"), "Filipinas" },
                    { new Guid("26952c68-ce98-4120-81d3-13f464bf27df"), "Finlandia" },
                    { new Guid("f9b83332-f60e-4394-952d-a4ec5e72963f"), "Francia" },
                    { new Guid("57ccaec3-cf27-4fad-a258-b5f82b6c1684"), "Gabón" },
                    { new Guid("3ac4eb91-31c7-4434-bb75-143a6e0b20b2"), "Gambia" },
                    { new Guid("21368897-2980-48e3-a0f4-696bf282104b"), "Georgia" },
                    { new Guid("28686eb9-9322-4312-8013-92dfaede089e"), "Croacia" },
                    { new Guid("9219b0c8-de46-45ac-8f04-59f883f39591"), "Zimbabue" }
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
