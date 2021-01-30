using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Models
{
    public class ContractorCreate
    {
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        

        [Display(Name = "First Name")] 
        public string FirstName { get; set; }

        public int Age { get; set; }

        public int JobId { get; set; }


    }

}
