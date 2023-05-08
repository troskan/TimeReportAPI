using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportAPI.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => x.ProjectEmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Oskar", "Holm" },
                    { 2, "Emma", "Larsson" },
                    { 3, "Gustav", "Andersson" },
                    { 4, "Sara", "Johansson" },
                    { 5, "Erik", "Lindberg" },
                    { 6, "Maja", "Söderberg" },
                    { 7, "Johan", "Bergström" },
                    { 8, "Lisa", "Ekström" },
                    { 9, "Per", "Gustafsson" },
                    { 10, "Anna", "Björk" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "ProjectEmployeeID", "EmployeeID", "ProjectID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 2 },
                    { 7, 7, 2 },
                    { 8, 8, 2 },
                    { 9, 9, 3 },
                    { 10, 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[,]
                {
                    { 1, "Vasa Museum" },
                    { 2, "The Royal Palace" },
                    { 3, "Drottningholm Palace" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportID", "EmployeeID", "Hours", "ProjectID" },
                values: new object[,]
                {
                    { 1, 1, 20, 0 },
                    { 2, 2, 30, 0 },
                    { 3, 3, 40, 0 },
                    { 4, 4, 25, 0 },
                    { 5, 5, 35, 0 },
                    { 6, 6, 30, 0 },
                    { 7, 7, 20, 0 },
                    { 8, 8, 15, 0 },
                    { 9, 9, 10, 0 },
                    { 10, 10, 20, 0 },
                    { 11, 11, 25, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TimeReports");
        }
    }
}
