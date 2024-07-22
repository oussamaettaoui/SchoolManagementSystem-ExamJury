using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Juries",
                keyColumn: "Id",
                keyValue: new Guid("40a95404-6f87-4dd6-804e-47b2f79cdf97"));

            migrationBuilder.DeleteData(
                table: "Juries",
                keyColumn: "Id",
                keyValue: new Guid("ab9e72c7-ef33-4c22-84c6-318c93a5c21b"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ad6957a-3aac-4586-b5ef-4093301b734e"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("355dff87-fd85-416e-b457-6250bb156cc2"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("4c03e145-5fc2-4f8e-9369-2a0279ca130d"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("f3348cbe-4578-4495-8782-d3d483d42fad"));

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "dayOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayOrderModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOrderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("09524f42-7987-4b75-94f7-5f2234702727"), new DateTime(2024, 7, 22, 11, 23, 50, 807, DateTimeKind.Utc).AddTicks(4560), "AGC Jury", new Guid("216a893d-740b-47bd-a689-065170b33437"), new DateTime(2024, 7, 22, 11, 23, 50, 807, DateTimeKind.Utc).AddTicks(4560) },
                    { new Guid("a324b7d9-bffa-4526-bd2f-9e5bf8dd350e"), new DateTime(2024, 7, 22, 11, 23, 50, 807, DateTimeKind.Utc).AddTicks(4570), "TIC Jury", new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"), new DateTime(2024, 7, 22, 11, 23, 50, 807, DateTimeKind.Utc).AddTicks(4570) }
                });

            migrationBuilder.InsertData(
                table: "JuryMemberRoles",
                columns: new[] { "Id", "CreatedAt", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2eae63d1-f596-4e2f-a110-1cf8f989e342"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre représentant l’Administration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51914d64-d605-44e4-877b-287841fff14e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre Professionnel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5fbeb837-57bc-444f-8161-80be702dd5b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre de l’établissement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffcf1ac7-66e4-4573-a375-48bb396f47be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Président", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOrderModel_IdMetting",
                table: "DayOrderModel",
                column: "IdMetting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOrderModel");

            migrationBuilder.DeleteData(
                table: "Juries",
                keyColumn: "Id",
                keyValue: new Guid("09524f42-7987-4b75-94f7-5f2234702727"));

            migrationBuilder.DeleteData(
                table: "Juries",
                keyColumn: "Id",
                keyValue: new Guid("a324b7d9-bffa-4526-bd2f-9e5bf8dd350e"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("2eae63d1-f596-4e2f-a110-1cf8f989e342"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("51914d64-d605-44e4-877b-287841fff14e"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fbeb837-57bc-444f-8161-80be702dd5b4"));

            migrationBuilder.DeleteData(
                table: "JuryMemberRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffcf1ac7-66e4-4573-a375-48bb396f47be"));

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "dayOrders");

            migrationBuilder.InsertData(
                table: "Juries",
                columns: new[] { "Id", "CreatedAt", "JuryName", "SectorId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("40a95404-6f87-4dd6-804e-47b2f79cdf97"), new DateTime(2024, 7, 22, 10, 53, 42, 899, DateTimeKind.Utc).AddTicks(940), "TIC Jury", new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"), new DateTime(2024, 7, 22, 10, 53, 42, 899, DateTimeKind.Utc).AddTicks(940) },
                    { new Guid("ab9e72c7-ef33-4c22-84c6-318c93a5c21b"), new DateTime(2024, 7, 22, 10, 53, 42, 899, DateTimeKind.Utc).AddTicks(930), "AGC Jury", new Guid("216a893d-740b-47bd-a689-065170b33437"), new DateTime(2024, 7, 22, 10, 53, 42, 899, DateTimeKind.Utc).AddTicks(930) }
                });

            migrationBuilder.InsertData(
                table: "JuryMemberRoles",
                columns: new[] { "Id", "CreatedAt", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2ad6957a-3aac-4586-b5ef-4093301b734e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre représentant l’Administration", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("355dff87-fd85-416e-b457-6250bb156cc2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre Professionnel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c03e145-5fc2-4f8e-9369-2a0279ca130d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Membre de l’établissement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3348cbe-4578-4495-8782-d3d483d42fad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Président", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
