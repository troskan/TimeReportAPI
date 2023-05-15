using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO
{
    public class CreateTimeReportDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }
    }
}
