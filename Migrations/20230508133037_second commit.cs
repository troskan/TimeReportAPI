using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportAPI.Migrations
{
    public partial class secondcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                table: "ProjectEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_ProjectID",
                table: "ProjectEmployees",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                table: "ProjectEmployees",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Projects_ProjectID",
                table: "ProjectEmployees",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                table: "ProjectEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_Projects_ProjectID",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployees_EmployeeID",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployees_ProjectID",
                table: "ProjectEmployees");
        }
    }
}
