using PrePositionOrganizer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class ApplicationCreate
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(8000)]
        public string JobDescription { get; set; }
        public double SalaryEstimate { get; set; }
        public string JobLocation { get; set; }
        [Required]
        public MyInterest MyInterest { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
