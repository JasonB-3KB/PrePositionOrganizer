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
        public string Text { get; set; }
        public int ApplicationId { get; set; }

        [Display(Name="Comment Added")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
