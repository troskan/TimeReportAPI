﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeReportAPI.Data;

#nullable disable

namespace TimeReportAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230510064247_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TimeReportClassLibrary.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            FirstName = "Oskar",
                            LastName = "Holm"
                        },
                        new
                        {
                            EmployeeID = 2,
                            FirstName = "Emma",
                            LastName = "Larsson"
                        },
                        new
                        {
                            EmployeeID = 3,
                            FirstName = "Gustav",
                            LastName = "Andersson"
                        },
                        new
                        {
                            EmployeeID = 4,
                            FirstName = "Sara",
                            LastName = "Johansson"
                        },
                        new
                        {
                            EmployeeID = 5,
                            FirstName = "Erik",
                            LastName = "Lindberg"
                        },
                        new
                        {
                            EmployeeID = 6,
                            FirstName = "Maja",
                            LastName = "Söderberg"
                        },
                        new
                        {
                            EmployeeID = 7,
                            FirstName = "Johan",
                            LastName = "Bergström"
                        },
                        new
                        {
                            EmployeeID = 8,
                            FirstName = "Lisa",
                            LastName = "Ekström"
                        },
                        new
                        {
                            EmployeeID = 9,
                            FirstName = "Per",
                            LastName = "Gustafsson"
                        },
                        new
                        {
                            EmployeeID = 10,
                            FirstName = "Anna",
                            LastName = "Björk"
                        });
                });

            modelBuilder.Entity("TimeReportClassLibrary.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"), 1L, 1);

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectID = 1,
                            ProjectName = "Vasa Museum"
                        },
                        new
                        {
                            ProjectID = 2,
                            ProjectName = "The Royal Palace"
                        },
                        new
                        {
                            ProjectID = 3,
                            ProjectName = "Drottningholm Palace"
                        });
                });

            modelBuilder.Entity("TimeReportClassLibrary.Models.ProjectEmployee", b =>
                {
                    b.Property<int>("ProjectEmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectEmployeeID"), 1L, 1);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("ProjectEmployeeID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectEmployees");

                    b.HasData(
                        new
                        {
                            ProjectEmployeeID = 1,
                            EmployeeID = 1,
                            ProjectID = 1
                        },
                        new
                        {
                            ProjectEmployeeID = 2,
                            EmployeeID = 2,
                            ProjectID = 1
                        },
                        new
                        {
                            ProjectEmployeeID = 3,
                            EmployeeID = 3,
                            ProjectID = 1
                        },
                        new
                        {
                            ProjectEmployeeID = 4,
                            EmployeeID = 4,
                            ProjectID = 1
                        },
                        new
                        {
                            ProjectEmployeeID = 5,
                            EmployeeID = 5,
                            ProjectID = 1
                        },
                        new
                        {
                            ProjectEmployeeID = 6,
                            EmployeeID = 6,
                            ProjectID = 2
                        },
                        new
                        {
                            ProjectEmployeeID = 7,
                            EmployeeID = 7,
                            ProjectID = 2
                        },
                        new
                        {
                            ProjectEmployeeID = 8,
                            EmployeeID = 8,
                            ProjectID = 2
                        },
                        new
                        {
                            ProjectEmployeeID = 9,
                            EmployeeID = 9,
                            ProjectID = 3
                        },
                        new
                        {
                            ProjectEmployeeID = 10,
                            EmployeeID = 10,
                            ProjectID = 3
                        });
                });

            modelBuilder.Entity("TimeReportClassLibrary.Models.TimeReport", b =>
                {
                    b.Property<int>("TimeReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeReportID"), 1L, 1);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeReportID");

                    b.ToTable("TimeReports");

                    b.HasData(
                        new
                        {
                            TimeReportID = 1,
                            EmployeeID = 1,
                            EndTime = new DateTime(2023, 4, 8, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 2,
                            EmployeeID = 2,
                            EndTime = new DateTime(2023, 4, 9, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 3,
                            EmployeeID = 3,
                            EndTime = new DateTime(2023, 4, 10, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 4,
                            EmployeeID = 4,
                            EndTime = new DateTime(2023, 4, 11, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 11, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 5,
                            EmployeeID = 5,
                            EndTime = new DateTime(2023, 4, 12, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 12, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 6,
                            EmployeeID = 6,
                            EndTime = new DateTime(2023, 4, 13, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 13, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 7,
                            EmployeeID = 7,
                            EndTime = new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 14, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 8,
                            EmployeeID = 8,
                            EndTime = new DateTime(2023, 4, 28, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 14, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 9,
                            EmployeeID = 9,
                            EndTime = new DateTime(2023, 4, 28, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 28, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 10,
                            EmployeeID = 10,
                            EndTime = new DateTime(2023, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 28, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeReportID = 11,
                            EmployeeID = 11,
                            EndTime = new DateTime(2023, 4, 28, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectID = 0,
                            StartTime = new DateTime(2023, 4, 28, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TimeReportClassLibrary.Models.ProjectEmployee", b =>
                {
                    b.HasOne("TimeReportClassLibrary.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeReportClassLibrary.Models.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
