using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Models
{
    public class JobDetail
    {

        public int JobId { get; set; }

        [Display(Name = "Description of Job")] 
        public string JobDescription { get; set; }
        [Display(Name = "Name of Job")]
        public string JobName { get; set; }
        public string City { get; set; }
        public int Price { get; set; } 
        public int EstimatedHours { get; set; }      
        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }
        
    }
}
