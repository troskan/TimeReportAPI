using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportAPI.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "TimeReports");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TimeReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TimeReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 11, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 5,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 6,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 13, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 7,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 28, 6, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TimeReports");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TimeReports");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "TimeReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 1,
                column: "Hours",
                value: 20);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 2,
                column: "Hours",
                value: 30);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 3,
                column: "Hours",
                value: 40);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 4,
                column: "Hours",
                value: 25);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 5,
                column: "Hours",
                value: 35);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 6,
                column: "Hours",
                value: 30);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 7,
                column: "Hours",
                value: 20);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 8,
                column: "Hours",
                value: 15);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 9,
                column: "Hours",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 10,
                column: "Hours",
                value: 20);

            migrationBuilder.UpdateData(
                table: "TimeReports",
                keyColumn: "TimeReportID",
                keyValue: 11,
                column: "Hours",
                value: 25);
        }
    }
}
