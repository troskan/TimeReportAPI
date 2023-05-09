using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReportClassLibrary.Models
{
    public class Project
    {
        [Key] public int ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
    }
}
