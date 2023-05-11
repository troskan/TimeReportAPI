using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO
{
    public class EmployeeTimeReportDTO
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TimeReportID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }
}
