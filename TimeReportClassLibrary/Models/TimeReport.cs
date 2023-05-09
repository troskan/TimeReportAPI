using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReportClassLibrary.Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportID { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int ProjectID { get; set; }
    }
}
