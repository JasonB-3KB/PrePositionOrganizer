using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }
        [Display(Name="Comment")]
        public string Text { get; set; }
        
    }
}
