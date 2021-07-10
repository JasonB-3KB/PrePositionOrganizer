using PrePositionOrganizer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class ApplicationEdit
    {
        public int ApplicationId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Description of job")]
        public string JobDescription { get; set; }

        [Display(Name = "Estimated Salary")]
        public string SalaryEstimate { get; set; }

        [Display(Name = "Job Location")]
        public string JobLocation { get; set; }

        [Display(Name = "My Interest Level")]
        public MyInterest MyInterest { get; set; }

        [Display(Name = "Current Status")]
        public Status Status { get; set; }
            
    }
}
