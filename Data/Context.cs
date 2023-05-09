using Microsoft.EntityFrameworkCore;
using System;
using TimeReportClassLibrary.Models;
namespace TimeReportAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, FirstName = "Oskar", LastName = "Holm" },
                new Employee { EmployeeID = 2, FirstName = "Emma", LastName = "Larsson" },
                new Employee { EmployeeID = 3, FirstName = "Gustav", LastName = "Andersson" },
                new Employee { EmployeeID = 4, FirstName = "Sara", LastName = "Johansson" },
                new Employee { EmployeeID = 5, FirstName = "Erik", LastName = "Lindberg" },
                new Employee { EmployeeID = 6, FirstName = "Maja", LastName = "Söderberg" },
                new Employee { EmployeeID = 7, FirstName = "Johan", LastName = "Bergström" },
                new Employee { EmployeeID = 8, FirstName = "Lisa", LastName = "Ekström" },
                new Employee { EmployeeID = 9, FirstName = "Per", LastName = "Gustafsson" },
                new Employee { EmployeeID = 10, FirstName = "Anna", LastName = "Björk" }
            );

            // Add 3 more projects
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectID = 1, ProjectName = "Vasa Museum" },
                new Project { ProjectID = 2, ProjectName = "The Royal Palace" },
                new Project { ProjectID = 3, ProjectName = "Drottningholm Palace" }
            );

            // Add time reports for each employee
            modelBuilder.Entity<TimeReport>().HasData(
                new TimeReport
                {
                    TimeReportID = 1,
                    EmployeeID = 1,
                    StartTime = new DateTime(2023, 4, 8, 8, 0, 0),
                    EndTime = new DateTime(2023, 4, 8, 16, 0, 0)
                },

                new TimeReport
                {
                    TimeReportID = 2,
                    EmployeeID = 2,
                    StartTime = new DateTime(2023, 4, 9, 8, 0, 0),
                    EndTime = new DateTime(2023, 4, 9, 13, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 3,
                    EmployeeID = 3,
                    StartTime = new DateTime(2023, 4, 10, 8, 0, 0),
                    EndTime = new DateTime(2023, 4, 10, 18, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 4,
                    EmployeeID = 4,
                    StartTime = new DateTime(2023, 4, 11, 6, 0, 0),
                    EndTime = new DateTime(2023, 4, 11, 12, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 5,
                    EmployeeID = 5,
                    StartTime = new DateTime(2023, 4, 12, 8, 0, 0),
                    EndTime = new DateTime(2023, 4, 12, 16, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 6,
                    EmployeeID = 6,
                    StartTime = new DateTime(2023, 4, 13, 8, 0, 0),
                    EndTime = new DateTime(2023, 4, 13, 17, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 7,
                    EmployeeID = 7,
                    StartTime = new DateTime(2023, 4, 14, 6, 0, 0),
                    EndTime = new DateTime(2023, 4, 14, 14, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 8,
                    EmployeeID = 8,
                    StartTime = new DateTime(2023, 4, 14, 6, 0, 0),
                    EndTime = new DateTime(2023, 4, 28, 16, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 9,
                    EmployeeID = 9,
                    StartTime = new DateTime(2023, 4, 28, 6, 0, 0),
                    EndTime = new DateTime(2023, 4, 28, 19, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 10,
                    EmployeeID = 10,
                    StartTime = new DateTime(2023, 4, 28, 9, 0, 0),
                    EndTime = new DateTime(2023, 4, 28, 15, 0, 0)
                },
                new TimeReport
                {
                    TimeReportID = 11,
                    EmployeeID = 11,
                    StartTime = new DateTime(2023, 4, 28, 9, 0, 0),
                    EndTime = new DateTime(2023, 4, 28, 18, 0, 0)
                }
            );

            // Add project employees
            modelBuilder.Entity<ProjectEmployee>().HasData(
                new ProjectEmployee { ProjectEmployeeID = 1, ProjectID = 1, EmployeeID = 1 },
                new ProjectEmployee { ProjectEmployeeID = 2, ProjectID = 1, EmployeeID = 2 },
                new ProjectEmployee { ProjectEmployeeID = 3, ProjectID = 1, EmployeeID = 3 },
                new ProjectEmployee { ProjectEmployeeID = 4, ProjectID = 1, EmployeeID = 4 },
                new ProjectEmployee { ProjectEmployeeID = 5, ProjectID = 1, EmployeeID = 5 },
                new ProjectEmployee { ProjectEmployeeID = 6, ProjectID = 2, EmployeeID = 6 },
                new ProjectEmployee { ProjectEmployeeID = 7, ProjectID = 2, EmployeeID = 7 },
                new ProjectEmployee { ProjectEmployeeID = 8, ProjectID = 2, EmployeeID = 8 },
                new ProjectEmployee { ProjectEmployeeID = 9, ProjectID = 3, EmployeeID = 9 },
                new ProjectEmployee { ProjectEmployeeID = 10, ProjectID = 3, EmployeeID = 10 }
            );


        }

    }
}
