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

            migrationBuilder.InsertData(
                table: "Juries",
                columns: new[] { "Id", "CreatedAt", "JuryName", "SectorId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("92695e86-944f-425a-b1c5-14f7dbd8652b"), new DateTime(2024, 7, 19, 10, 50, 54, 276, DateTimeKind.Utc).AddTicks(1126), "AGC Jury", new Guid("216a893d-740b-47bd-a689-065170b33437"), new DateTime(2024, 7, 19, 10, 50, 54, 276, DateTimeKind.Utc).AddTicks(1131) },
                    { new Guid("ca642b1a-51c6-4140-984b-b6ad62f754bd"), new DateTime(2024, 7, 19, 10, 50, 54, 276, DateTimeKind.Utc).AddTicks(1138), "TIC Jury", new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"), new DateTime(2024, 7, 19, 10, 50, 54, 276, DateTimeKind.Utc).AddTicks(1138) }
                });

            migrationBuilder.InsertData(
                table: "JuryMemberRoles",
                columns: new[] { "Id", "CreatedAt", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11ac01df-8776-4f36-974d-0eecc522941f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre Professionnel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("665d666d-2013-4865-9b88-7e0d25b53fd9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Président", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b398b593-36ca-49d9-97bd-58fa0a322e80"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre représentant l’Administration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd25824c-57a3-4caf-ba77-f3491967dda6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre de l’établissement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
