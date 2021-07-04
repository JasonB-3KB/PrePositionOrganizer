using PrePositionOrganizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class ApplicationEdit
    {
        public int ApplicationId { get; set; }
        public MyInterest MyInterest { get; set; }
        public Status Status { get; set; }
        
    }
}
