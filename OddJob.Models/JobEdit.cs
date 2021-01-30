using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }

        public string JobName { get; set; }
        [Display(Name = "Job Name")]

        public string JobDescription { get; set; }
        [Display(Name = "Description of Job")]
        
       
        public int Price { get; set; }
        public int EstimatedHours { get; set; }
    }
}
