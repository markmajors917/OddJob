using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Datal
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        [Display(Name = "Description of Job")]
        [Required]
        public string City { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int EstimatedHours { get; set; }
        [Required]
        public bool Complete { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public Guid OwnerId { get; set; }
    }
}
