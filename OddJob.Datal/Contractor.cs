using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Datal
{
    public class Contractor
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public int ParentId { get; set; }
        public int Age { get; set; }
        public Guid UserId { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public Guid OwnerId { get; set; }


    }
}
