using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Data
{
    public enum MyInterest { Hot, Medium, Cold }
    public enum Status { Just_Applied, In_Contact, Interviewing, Closed_Door }

    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name ="Description of job")]
        public string JobDescription { get; set; }
        
        [Display(Name ="Estimated Salary")]
        public string SalaryEstimate { get; set; }
        
        [Display(Name ="Job Location")]
        public string JobLocation { get; set; }

        //Maybe this will work>>
        
        //[Required]
        //[ForeignKey(nameof(Comment))]
        //public int CommentId { get; set; }
        //public string Text { get; set; }
        public virtual List<Comment> Comments { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ?ModifiedUtc { get; set; }

        [Required]
        [Display(Name ="My Interest Level")]
        public MyInterest MyInterest { get; set; }
        [Required]
        [Display(Name ="Current Status of Application")]
        public Status Status { get; set; }
    }
}
