using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TimeReportAPI.DTO
{
    public class EmployeeTimeReportDTO
    {
        public int TimeReportID { get; set; }
        public double TotalHoursWorked { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }
}
