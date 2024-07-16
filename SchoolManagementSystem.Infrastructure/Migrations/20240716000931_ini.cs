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

            migrationBuilder.InsertData(
                table: "Juries",
                columns: new[] { "Id", "CreatedAt", "JuryName", "SectorId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("c1451641-074b-4969-9fb9-f0c60e2ed4c9"), new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2497), "AGC Jury", new Guid("216a893d-740b-47bd-a689-065170b33437"), new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2499) },
                    { new Guid("dd8139f1-30bd-4891-80c5-da91bb0bae8b"), new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2506), "TIC Jury", new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"), new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2506) }
                });

            migrationBuilder.InsertData(
                table: "JuryMemberRoles",
                columns: new[] { "Id", "CreatedAt", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("39a8a8d2-fe1a-444a-bc8f-2d2a8b77afbd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Président", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("68ebdaa7-3721-4e43-b3e9-c2c6f83374de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre représentant l’Administration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e4ee989-e85f-401f-b77e-3ea952892875"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre Professionnel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9810844-4b59-4805-ad3b-350d0bfa82e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre de l’établissement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
