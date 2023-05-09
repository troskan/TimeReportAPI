using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReportClassLibrary.Models
{
    public class ProjectEmployee
    {
        [Key]
        public int ProjectEmployeeID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public Employee? Employees { get; set; }
        public int ProjectID { get; set; }
        public Project Projects { get; set; }

    }
}
