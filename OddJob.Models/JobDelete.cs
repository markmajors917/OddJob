using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Models
{
    public class JobDelete
    {
        [Display(Name = "Choose existing Job")]
        public int? JobId { get; set; }

        [Display(Name = "Job Name")]
        public string JobName { get; set; }

        [Display(Name = "Decription of the Job")]
        public string JobDescription { get; set; }

        public string Content { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int EstimatedHours { get; set; }
        [Required]
        public bool Complete { get; set; }
    }
}
