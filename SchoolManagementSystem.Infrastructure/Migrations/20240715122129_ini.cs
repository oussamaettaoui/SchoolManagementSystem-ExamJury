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
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { new Guid("59d1b85a-c0e0-4dfb-84a3-baa8285d6864"), new DateTime(2024, 7, 15, 12, 21, 27, 871, DateTimeKind.Utc).AddTicks(990), "TIC Jury", new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"), new DateTime(2024, 7, 15, 12, 21, 27, 871, DateTimeKind.Utc).AddTicks(991) },
                    { new Guid("d3b07d82-761f-441d-9c89-a634ea7c2efc"), new DateTime(2024, 7, 15, 12, 21, 27, 871, DateTimeKind.Utc).AddTicks(980), "AGC Jury", new Guid("216a893d-740b-47bd-a689-065170b33437"), new DateTime(2024, 7, 15, 12, 21, 27, 871, DateTimeKind.Utc).AddTicks(984) }
                });

            migrationBuilder.InsertData(
                table: "JuryMemberRoles",
                columns: new[] { "Id", "CreatedAt", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11b562fa-12e1-4b28-9f88-44784d6b426e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre Professionnel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26086d3c-60d8-4368-bc7d-34de1ed32fe2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Président", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ec67cfc-cc72-4822-a7c3-4ee85464f9cb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre de l’établissement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f57d6a2-6953-4fcf-bf6f-2d4e2ff88004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre représentant l’Administration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
