using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Reinmar.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaybillHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CashOnDelivery = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    InvoiceId = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OrderName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    SitId = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waybills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HeaderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waybills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waybills_WaybillHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "WaybillHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaybillBodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CargoName = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsAssembly = table.Column<bool>(nullable: false),
                    IsCollection = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Service = table.Column<string>(nullable: true),
                    SitId = table.Column<int>(nullable: false),
                    WaybillHeadersId = table.Column<Guid>(nullable: true),
                    WaybillId = table.Column<Guid>(nullable: true),
                    Zone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillBodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaybillBodies_WaybillHeaders_WaybillHeadersId",
                        column: x => x.WaybillHeadersId,
                        principalTable: "WaybillHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaybillBodies_Waybills_WaybillId",
                        column: x => x.WaybillId,
                        principalTable: "Waybills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Statusses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    WaybillBodiesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statusses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statusses_WaybillBodies_WaybillBodiesId",
                        column: x => x.WaybillBodiesId,
                        principalTable: "WaybillBodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Statusses_WaybillBodiesId",
                table: "Statusses",
                column: "WaybillBodiesId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillBodies_WaybillHeadersId",
                table: "WaybillBodies",
                column: "WaybillHeadersId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillBodies_WaybillId",
                table: "WaybillBodies",
                column: "WaybillId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybills_HeaderId",
                table: "Waybills",
                column: "HeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Statusses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WaybillBodies");

            migrationBuilder.DropTable(
                name: "Waybills");

            migrationBuilder.DropTable(
                name: "WaybillHeaders");
        }
    }
}
