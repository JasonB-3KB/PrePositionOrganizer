using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        [Display(Name ="Comment")]
        public string Text { get; set; }
        [Display(Name = "Comment Added")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Comment updated")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
