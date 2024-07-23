using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dayOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOrderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dayOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Juries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JuryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JuryMemberRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuryMemberRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    JuryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Juries_JuryId",
                        column: x => x.JuryId,
                        principalTable: "Juries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuryMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false),
                    LatestDiploma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JuryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuryMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuryMembers_Juries_JuryId",
                        column: x => x.JuryId,
                        principalTable: "Juries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuryMembers_JuryMemberRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "JuryMemberRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayOrderModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOrderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMetting = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOrderModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOrderModel_Meeting_IdMetting",
                        column: x => x.IdMetting,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Juries",
                columns: new[] { "Id", "CreatedAt", "JuryName", "SectorId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("42b598ec-cfa5-4455-b990-3902acc43852"), new DateTime(2024, 7, 22, 22, 3, 57, 695, DateTimeKind.Utc).AddTicks(8033), "AGC Jury", new Guid("216a893d-740b-47bd-a689-065170b33437"), new DateTime(2024, 7, 22, 22, 3, 57, 695, DateTimeKind.Utc).AddTicks(8037) },
                    { new Guid("5a19e0e1-ac97-4f4c-a3fd-41167438f5a1"), new DateTime(2024, 7, 22, 22, 3, 57, 695, DateTimeKind.Utc).AddTicks(8057), "TIC Jury", new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"), new DateTime(2024, 7, 22, 22, 3, 57, 695, DateTimeKind.Utc).AddTicks(8057) }
                });

            migrationBuilder.InsertData(
                table: "JuryMemberRoles",
                columns: new[] { "Id", "CreatedAt", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2bc43749-192c-4a65-a8bb-164e17100527"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre Professionnel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53cdfc4d-c617-403b-9457-4bd704535c0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Président", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a49db16-39c3-40bb-bcfd-2e683f294f59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre de l’établissement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6080122-f6cf-4cd8-a576-c298fa246cb4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre représentant l’Administration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOrderModel_IdMetting",
                table: "DayOrderModel",
                column: "IdMetting");

            migrationBuilder.CreateIndex(
                name: "IX_JuryMembers_JuryId",
                table: "JuryMembers",
                column: "JuryId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryMembers_RoleId",
                table: "JuryMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_JuryId",
                table: "Meeting",
                column: "JuryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOrderModel");

            migrationBuilder.DropTable(
                name: "dayOrders");

            migrationBuilder.DropTable(
                name: "JuryMembers");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "JuryMemberRoles");

            migrationBuilder.DropTable(
                name: "Juries");
        }
    }
}
