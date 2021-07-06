using PrePositionOrganizer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class ApplicationListItem
    {
        public int ApplicationId { get; set; }
        [Display(Name="Name of Company")]
        public string CompanyName { get; set; }
        [Display(Name ="Description of job")]
        public string JobDescription { get; set; }

        [Display(Name = "Current Status of Application")]
        public Status Status { get; set; }

        [Display(Name ="Application Date")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
