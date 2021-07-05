using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        [Display(Name ="Comments")]
        public string Text { get; set; }
        [Display(Name ="Company Name")]
        public string ApplicationId { get; set; }

        [Display(Name="Comment Added")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
