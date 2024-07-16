﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.Infrastructure.Data;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Jury", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("JuryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Juries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1451641-074b-4969-9fb9-f0c60e2ed4c9"),
                            CreatedAt = new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2497),
                            JuryName = "AGC Jury",
                            SectorId = new Guid("216a893d-740b-47bd-a689-065170b33437"),
                            UpdatedAt = new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2499)
                        },
                        new
                        {
                            Id = new Guid("dd8139f1-30bd-4891-80c5-da91bb0bae8b"),
                            CreatedAt = new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2506),
                            JuryName = "TIC Jury",
                            SectorId = new Guid("0caff05b-d501-426f-948d-a841be4a1a3c"),
                            UpdatedAt = new DateTime(2024, 7, 16, 0, 9, 30, 928, DateTimeKind.Utc).AddTicks(2506)
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.JuryMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JuryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatestDiploma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("YearOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JuryId");

                    b.HasIndex("RoleId");

                    b.ToTable("JuryMembers");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.JuryMemberRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JuryMemberRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39a8a8d2-fe1a-444a-bc8f-2d2a8b77afbd"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Président",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("6e4ee989-e85f-401f-b77e-3ea952892875"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Membre Professionnel",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e9810844-4b59-4805-ad3b-350d0bfa82e5"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Membre de l’établissement",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("68ebdaa7-3721-4e43-b3e9-c2c6f83374de"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Membre représentant l’Administration",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JuryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("JuryId");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.JuryMember", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Entities.Jury", "Jury")
                        .WithMany("JuryMembers")
                        .HasForeignKey("JuryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Domain.Entities.JuryMemberRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jury");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Meeting", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Entities.Jury", "Jury")
                        .WithMany()
                        .HasForeignKey("JuryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jury");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Jury", b =>
                {
                    b.Navigation("JuryMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
