using PrePositionOrganizer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrePositionOrganizer.Models
{
    public class CommentCreate
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Text { get; set; }
        
        [ForeignKey(nameof(Application))]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        

    }
}
