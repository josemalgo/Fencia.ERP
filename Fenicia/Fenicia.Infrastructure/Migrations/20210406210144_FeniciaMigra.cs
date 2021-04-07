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
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FiscalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    FiscalAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_FiscalAddressId",
                        column: x => x.FiscalAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("eb56fb24-06da-44ed-90da-c04a0bcd1f8b"), "Afganistán" },
                    { new Guid("3dd42c50-7342-417e-ae6c-88bb7225bdb1"), "Mozambique" },
                    { new Guid("4fb9b526-19b3-4198-849e-c6913adb16d1"), "Birmania" },
                    { new Guid("60630536-223e-4bed-99dd-032371715d37"), "Namibia" },
                    { new Guid("66552f12-12af-46fb-948b-e83f6d115818"), "Nauru" },
                    { new Guid("eee373c4-cd31-47d0-a027-e428eeac9072"), "Nepal" },
                    { new Guid("56901d22-4f43-4c7e-8851-2fdfe8719115"), "Nicaragua" },
                    { new Guid("a215ad97-2e2b-43c0-9ac9-eef86b758d99"), "Níger" },
                    { new Guid("d465615c-9d48-4835-b819-da387460873c"), "Nigeria" },
                    { new Guid("1e6bd2c0-3579-4251-9547-2e71dc80c7a0"), "Noruega" },
                    { new Guid("bf185444-c41f-47c8-9549-a8b236c14771"), "Montenegro" },
                    { new Guid("8de8a4d4-0966-427a-8473-27835e6c5398"), "Nueva Zelanda" },
                    { new Guid("fb7132b5-c76b-4751-955b-1a910c81962b"), "Países Bajos" },
                    { new Guid("696aca2c-1029-4b5d-8cef-bd7675f1d80e"), "Pakistán" },
                    { new Guid("fcae26d6-b674-4763-8f20-3cfde47973ad"), "Palaos" },
                    { new Guid("afb7205c-abe9-402b-8442-c3852308260d"), "Panamá" },
                    { new Guid("3c7dff95-a5f1-408e-9689-e8771306476d"), "Papúa Nueva Guinea" },
                    { new Guid("2a418d01-681d-4983-b5e8-13e41787cc8b"), "Paraguay" },
                    { new Guid("6a38bd5a-6777-4e21-b971-34f11db78eab"), "Perú" },
                    { new Guid("233360ba-be36-401a-a03d-feaccc511049"), "Polonia" },
                    { new Guid("20ca449e-20b2-4a52-9068-9a7cfe832de1"), "Portugal" },
                    { new Guid("9a796311-6cef-4a03-932d-4307b3338444"), "Omán" },
                    { new Guid("55e5280f-5293-4bc0-a9e5-87be47a7370c"), "Mongolia" },
                    { new Guid("acb85ba5-59bf-4ace-aada-4fa13d4ab7ff"), "Mónaco" },
                    { new Guid("a2eba3f5-fccb-46d3-82e3-842eabb83c68"), "Moldavia" },
                    { new Guid("f71b9221-0120-4f8b-b586-9e611ce34cb0"), "Lesoto" },
                    { new Guid("cde1d644-d515-4e93-a5e2-e5274a50f59a"), "Letonia" },
                    { new Guid("6eb2e4d5-8c03-4ffc-a4e9-97c7d998dd3c"), "Líbano" },
                    { new Guid("81a9c71d-b052-432f-91fe-679ae73b3bee"), "Liberia" },
                    { new Guid("dea11d69-ed06-4265-8fc2-6b995d68ec37"), "Libia" },
                    { new Guid("e5b043c5-7241-4473-9331-013d43924913"), "Liechtenstein" },
                    { new Guid("3abd3d96-da00-4052-9d0a-441c452d0426"), "Lituania" },
                    { new Guid("8d7bd249-afd5-4479-ae48-76e13039d6a6"), "Luxemburgo" },
                    { new Guid("ec3d97ea-6f8e-403e-b119-9d2ddbd5b331"), "Macedonia" },
                    { new Guid("ceacf146-ebff-4f28-9647-41329707fd04"), "Madagascar" },
                    { new Guid("0277d428-dfb1-4ddf-92f9-d3448454a8ad"), "Malasia" },
                    { new Guid("a5458fde-161c-4844-b55c-8cad9f293ac0"), "Malaui" },
                    { new Guid("664a13c0-3ffc-4931-8f00-7a3b1581d4f4"), "Maldivas" },
                    { new Guid("bf3f237b-f666-4df8-9504-3e898719723b"), "Mali / Malí" },
                    { new Guid("5a113c6a-d63f-4476-a553-1ca2babf4170"), "Malta" },
                    { new Guid("342e9f8b-8e53-4d70-bf53-08952980185a"), "Marruecos" },
                    { new Guid("fa6e5458-78c6-4210-af45-c3a2f3f24f26"), "Islas Marshall" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("97ac6f32-79f4-4630-9484-c27f44084d07"), "Mauricio" },
                    { new Guid("43e485db-63c3-4aa5-acf9-8acb00e169f2"), "Mauritania" },
                    { new Guid("dfe0da7f-af7f-41fb-ad0f-5173d2691d12"), "México" },
                    { new Guid("7068725f-b337-4326-8fe1-78349e90dac9"), "Micronesia" },
                    { new Guid("9fb6f694-9a70-4987-89c9-0ec9d659599e"), "Qatar" },
                    { new Guid("5d966f6f-a3f8-4684-a04e-e7874ba8c4e0"), "Laos" },
                    { new Guid("3f4d6d11-4153-472b-a42c-26565c9bbf1e"), "Reino Unido" },
                    { new Guid("57727304-93bf-416d-9b7f-abac466d0b8b"), "República Dominicana" },
                    { new Guid("bbc7e5b2-d250-4c05-96c8-1f409f4efe20"), "Suazilandia" },
                    { new Guid("28184bb3-c442-4b18-942a-1b49ee8a0f07"), "Tailandia" },
                    { new Guid("9e7442ff-69be-436c-aade-60d51c41993a"), "Tanzania" },
                    { new Guid("4bcb9532-c44e-4f07-873e-64909334c859"), "Tayikistán" },
                    { new Guid("17c6f5f7-10b3-491d-8f0f-abe487bad163"), "Timor Oriental" },
                    { new Guid("5c0dd20c-58b0-4a92-aea5-c11fda76ecff"), "Togo" },
                    { new Guid("98168e7f-7e32-48e7-8bd5-85314bf2ac6e"), "Tonga" },
                    { new Guid("7dfca5ce-9b11-4106-b7aa-c6cf63306b1c"), "Trinidad y Tobago" },
                    { new Guid("1cc6db93-f469-4c62-a502-39508a333997"), "Túnez" },
                    { new Guid("71503eee-d272-49f1-acb5-b18f50dedf87"), "Surinam" },
                    { new Guid("9a78c4c1-4bbd-4110-b81f-a41d29b6b1a2"), "Turkmenistán" },
                    { new Guid("9424eac0-783a-4658-be07-aeb035ffe0e1"), "Tuvalu" },
                    { new Guid("884cd5a4-40b9-4bfa-b4be-1ccac879baa1"), "Ucrania" },
                    { new Guid("48a37b41-04f2-4770-b077-c353ab4d49c7"), "Uganda" },
                    { new Guid("4eb0e44c-6436-43da-8bdc-7d7a19cdb593"), "Uruguay" },
                    { new Guid("17b2a4cf-9aaf-40c5-b3e0-d6a9ada1a14b"), "Uzbekistán" },
                    { new Guid("8e83f847-6499-4c84-9806-2650320f8bcb"), "Vanuatu" },
                    { new Guid("468591c4-133b-4103-95c5-f9c38c0f028f"), "Venezuela" },
                    { new Guid("72a6d9de-2788-41c4-8903-f76e935f1845"), "Vietnam" },
                    { new Guid("ba55be95-da5e-42de-a2c1-0e5f5b2f4671"), "Yemen" },
                    { new Guid("8d1af0e6-e41d-41f9-ba3d-6d626671715b"), "Turquía" },
                    { new Guid("f2ccb787-c588-43d2-a991-29e38086e897"), "Suiza" },
                    { new Guid("f607c9f5-0557-48a4-a021-3a31b2ff3ae8"), "Suecia" },
                    { new Guid("cd6b4861-4cee-46b1-a3ce-4ba494234b2d"), "Sudán del Sur" },
                    { new Guid("d05f7b31-babf-48b1-bcae-2d40d1e4b3ab"), "Rumanía / Rumania" },
                    { new Guid("bda7c754-d499-4a40-8a20-7f29ec9bf86f"), "Rusia" },
                    { new Guid("aa728aea-f664-4dfe-86c3-554ade996cad"), "Ruanda" },
                    { new Guid("51fa3b52-ae99-437f-abee-de1efd66d3da"), "San Cristóbal y Nieves" },
                    { new Guid("73f2c203-c5bb-45ef-90c1-156ce448ce0d"), "Islas Salomón" },
                    { new Guid("46688518-d3e1-4afe-9937-21a7143b1dca"), "Samoa" },
                    { new Guid("88c5a6e7-55a8-49b1-a0bf-5ee48d60905d"), "San Marino" },
                    { new Guid("3f79bf7a-ec7b-453c-bfae-af31a1e95844"), "Santa Lucía" },
                    { new Guid("ab953ab3-3936-41f1-a137-683d20f30bac"), "Ciudad del Vaticano" },
                    { new Guid("abf29b11-6b09-4cc4-84b1-db52aec0332c"), "Santo Tomé y Príncipe" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f0898b4b-fbba-4e0f-bd75-1dbfcdb8a895"), "San Vicente y las Granadinas" },
                    { new Guid("c2bbb03b-47ef-4256-a105-5a01a75045e1"), "Senegal" },
                    { new Guid("2d1463ec-3d5a-43d7-ba21-f1724677e9c8"), "Serbia" },
                    { new Guid("a4eb312d-6c17-45f6-8b10-36b53bca55e2"), "Seychelles" },
                    { new Guid("d6eb6492-d216-4d0b-8381-1688b783e433"), "Sierra Leona" },
                    { new Guid("57072c25-485b-4ef8-8400-52f5d39191bd"), "Singapur" },
                    { new Guid("0e7bd917-7a52-43a2-aee0-c431580b335d"), "Siria" },
                    { new Guid("dfd1154c-2d68-4c1d-af1c-e4c1a58676a5"), "Somalia" },
                    { new Guid("6b8f1068-5bb6-405d-ae35-369906b2442d"), "Sri Lanka" },
                    { new Guid("02944167-848b-4e44-99ef-2d0dd775d06f"), "Sudáfrica" },
                    { new Guid("eda6fd38-13b7-4141-96a8-c662a0496aba"), "Sudán" },
                    { new Guid("83a94f27-6249-4325-b033-0239bcdddc7f"), "República Centroafricana" },
                    { new Guid("644703cf-cf96-4d26-877c-0dda968861c2"), "Zambia" },
                    { new Guid("34677ab6-ad40-4b68-a980-31dfd1b5ec52"), "Kuwait" },
                    { new Guid("f6a261d2-bad3-4343-8d71-5555ae801ecd"), "Kirguistán" },
                    { new Guid("2dbb860d-cf6e-4b6a-9fcb-a653f1ef6706"), "Brunéi" },
                    { new Guid("2dbedcd9-4c9b-420e-bd48-3c0466f7fafe"), "Bulgaria" },
                    { new Guid("16b83b52-dea5-4c2d-ad36-4257c7ea1f20"), "Burkina Faso" },
                    { new Guid("f82079a9-4885-45fd-b58d-388d33707338"), "Burundi" },
                    { new Guid("0264affa-9ffb-47d8-82ef-2b56b2a42fdc"), "Cabo Verde" },
                    { new Guid("e0c72793-3bc6-4e34-b2a4-045b4fcf526f"), "Camboya" },
                    { new Guid("c23c7510-85ec-43a4-bf10-22e8772aab60"), "Camerún" },
                    { new Guid("cd3666ee-c10e-4e86-80a1-5ed645ecd544"), "Canadá" },
                    { new Guid("e5948554-37b2-47e7-b91a-b3dfef8bfa4c"), "Chad" },
                    { new Guid("a923cb41-e0f3-428e-8a0f-3289d56dd81e"), "Brasil" },
                    { new Guid("95d57d9d-e086-4303-906c-4358a974c0f7"), "República Checa" },
                    { new Guid("48054392-8001-4571-9e62-386b4f5e9954"), "Chile" },
                    { new Guid("16ec0228-11fd-408d-a3d8-8a54bfa9ebdf"), "China" },
                    { new Guid("f0e05a5a-8d71-46e5-9020-92ffc17f95ca"), "Chipre" },
                    { new Guid("ff987ee1-546a-4d33-9770-2b196cebf285"), "Colombia" },
                    { new Guid("ff3f9ebb-7e85-4d19-984b-083aba3fae71"), "Comoras" },
                    { new Guid("2b32de72-acb0-41ed-9062-574356d515be"), "Congo" },
                    { new Guid("80fa2c84-2876-45b5-a893-290bc0bd7ffd"), "República Democrática del Congo" },
                    { new Guid("6ef0d169-ff67-4a9f-abd0-c8c577b81cef"), "Corea del Norte" },
                    { new Guid("6007c345-a9fd-4893-96c3-e4aaa332f669"), "Corea del Sur" },
                    { new Guid("818169ff-256e-4ba7-9629-32b8b4502603"), "Chequia" },
                    { new Guid("0dc92224-8506-4a28-8525-ae2031d47948"), "Botsuana" },
                    { new Guid("aca24e20-bb51-47ad-a91f-ec1dea83881f"), "Bosnia-Herzegovina" },
                    { new Guid("f94b7eff-af5f-4999-9e29-73aa9d098f9f"), "Bolivia" },
                    { new Guid("91bf8023-25b2-4afc-afe4-1ddaf3b7279e"), "Albania" },
                    { new Guid("150d126d-d7c2-4c71-9783-622b27a811ee"), "Alemania" },
                    { new Guid("57b6d08c-132e-447d-8733-72059cf993c3"), "Andorra" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("493e114b-5ec2-430d-a906-9ccaa0b2fcb5"), "Angola" },
                    { new Guid("1f393e0a-5a35-4975-8732-a25d9381d592"), "Antigua y Barbuda" },
                    { new Guid("48e16c1a-d25d-4ebe-a921-9c0aff26b83d"), "Arabia Saudita" },
                    { new Guid("826f62c2-fe00-4799-9fd3-ae05d5014f45"), "Argelia" },
                    { new Guid("95ac20a8-0c79-4519-951b-77dde3e211fc"), "Argentina" },
                    { new Guid("5557899b-d6e6-455b-a989-044ee0c0f156"), "Armenia" },
                    { new Guid("ee43e494-cffc-43c7-b156-f0de0f273a96"), "Australia" },
                    { new Guid("10f896ac-c48e-422a-a0de-9374a9c04555"), "Austria" },
                    { new Guid("a7b1b122-0ec8-40df-8e39-a55e510cc8f2"), "Azerbaiyán" },
                    { new Guid("a81e1838-5bcb-4592-a817-15b4ba025df3"), "Bahamas" },
                    { new Guid("cfe941e5-b767-4ccd-9c19-1d8dc03f2e0b"), "Bahréin" },
                    { new Guid("af239b5b-e8f0-4ff6-9acb-80d7f21586fc"), "Bangladés" },
                    { new Guid("88b080cc-09a5-4ad5-9013-739decd7cfc3"), "Barbados" },
                    { new Guid("42a490ff-08a9-468f-8a69-e20da73895ca"), "Bielorrusia" },
                    { new Guid("b5cb6428-d6d9-4ab1-87c4-84207b66e469"), "Bélgica" },
                    { new Guid("ddaa8deb-f986-4a75-9d49-f8c2ead7baec"), "Belice" },
                    { new Guid("01c486a7-a600-4878-99ff-e7eba7bec2b2"), "Benín" },
                    { new Guid("102b39a9-2fdc-48d0-aa66-cc311aca4b7e"), "Bután" },
                    { new Guid("5d5a6b2f-2889-4221-8352-60c0129954a7"), "Costa Rica" },
                    { new Guid("d4901cd7-6342-44fd-83fe-92c457707fa2"), "Kiribati" },
                    { new Guid("e2efc0c7-527e-4bfb-8cff-8c0c9a9b9721"), "Costa de Marfil" },
                    { new Guid("bf05270f-0503-486e-828d-1fc7ea34234b"), "Cuba" },
                    { new Guid("25880281-7eb3-4ec8-b8bf-a20b6e70b1f5"), "Guinea" },
                    { new Guid("c0b70d96-db88-4570-8231-0a6964e51096"), "Guinea-Bissau" },
                    { new Guid("1de9ff95-4c6b-4e9d-be04-b11f623562ac"), "Guinea Ecuatorial" },
                    { new Guid("bd061076-031d-4a11-8aab-12a6f23b98fb"), "Guyana" },
                    { new Guid("e7ee3cd3-0716-4d67-9e18-f4c01a3b78e3"), "Haití" },
                    { new Guid("a0706e3a-54da-4f3b-bfa0-b49ca23602b3"), "Honduras" },
                    { new Guid("92418b77-c61e-4de6-b55f-6d9a35716051"), "Hungría" },
                    { new Guid("4d84af31-7e25-4840-a711-5daebd7a3f99"), "India" },
                    { new Guid("bf921fa0-2186-4709-bed1-d01d8bdce051"), "Indonesia" },
                    { new Guid("9ae03fef-11b3-4ed8-a534-b09b2f004304"), "Guatemala" },
                    { new Guid("0b7ce0c6-0ab2-41c9-985b-9a6274c39aca"), "Irán" },
                    { new Guid("40ae4bdd-dee2-4daf-9ef7-b40de5b12476"), "Irlanda" },
                    { new Guid("a92f4a24-7cfe-4c85-9701-6761b4279d61"), "Islandia" },
                    { new Guid("77f11941-e0dd-477b-aa69-e0d566cdb1b3"), "Israel" },
                    { new Guid("7008b003-0734-4b67-8c71-e8ac7f07a1f1"), "Italia" },
                    { new Guid("48bec0bd-9971-4529-b556-17f2564f0c3d"), "Jamaica" },
                    { new Guid("430a8890-e9fc-43cd-beba-e2cfc54586fe"), "Japón" },
                    { new Guid("5e780da3-acd6-4268-bac5-b51caa72caee"), "Jordania" },
                    { new Guid("2b8ca6e6-6202-4c31-96ba-4c149f9a0125"), "Kazajistán" },
                    { new Guid("6d97c924-6db8-42af-bec6-a59efc994505"), "Kenia" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11339739-76fd-46ce-b481-dfa9ab718e8f"), "Iraq" },
                    { new Guid("cfdb2b63-61e4-4b32-865c-e9772cb406cc"), "Grecia" },
                    { new Guid("1f983841-31ff-4a0e-9eb7-a58a64f3273b"), "Granada" },
                    { new Guid("7a0c5f6e-e430-483e-9d21-b03b9dedc00c"), "Ghana" },
                    { new Guid("e6f57f20-7d4e-4b25-a34a-0a6b15fa5eb9"), "Dinamarca" },
                    { new Guid("714a43f4-d466-4f8b-a046-55847ee2582f"), "Yibuti" },
                    { new Guid("c3bf6d8b-1726-4d86-bb62-a65c00f592e5"), "Dominica" },
                    { new Guid("d30c5ad2-fe5f-4c93-a53e-ba48a4de3194"), "Ecuador" },
                    { new Guid("9ff61a44-6345-4b24-96fc-b131f6b80339"), "Egipto" },
                    { new Guid("4852bb26-c9c4-4834-b35b-f33f5ab0df0d"), "El Salvador" },
                    { new Guid("963b068e-ddcc-41f9-bcd2-f525d766bd48"), "Emiratos Árabes Unidos" },
                    { new Guid("ba924725-aefe-4149-aafc-79afbadca40a"), "Eritrea" },
                    { new Guid("c8616297-517a-4e90-9885-6b277917ef8b"), "Eslovaquia" },
                    { new Guid("16228ed8-631e-4f8d-9279-4e362d6937bf"), "Eslovenia" },
                    { new Guid("f64c74cc-1c8d-43df-9921-9d2104887477"), "España" },
                    { new Guid("554f65a6-8831-421b-81ca-98c52efdbf96"), "Estados Unidos" },
                    { new Guid("db529abc-3a27-454a-af2d-d56a70d24dfb"), "Estonia" },
                    { new Guid("3670f447-cb81-43ef-8d8f-e513de3a5bc8"), "Etiopía" },
                    { new Guid("6fbd6d28-63a3-4ecc-b0ae-34edb6d49e45"), "Fiyi" },
                    { new Guid("595e68f3-b969-4ec9-a304-1f2e39c9e906"), "Filipinas" },
                    { new Guid("3204bf89-0aac-4049-bc54-017774f02c30"), "Finlandia" },
                    { new Guid("d8af359c-f74e-46ad-bf83-8880d1ab4190"), "Francia" },
                    { new Guid("6523bcee-2d97-495e-bf99-882f4549c87f"), "Gabón" },
                    { new Guid("28b114a5-1d43-48b0-b4ac-2ad74c8b9e0b"), "Gambia" },
                    { new Guid("99bc3255-9cbe-49aa-8d22-ead865a15fdc"), "Georgia" },
                    { new Guid("e9017f10-2e22-4014-879a-ac4450347bc0"), "Croacia" },
                    { new Guid("487e6105-477b-4b74-83d1-8b30b34a2a03"), "Zimbabue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

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
                name: "IX_Customer_FiscalAddressId",
                table: "Customer",
                column: "FiscalAddressId");

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
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
