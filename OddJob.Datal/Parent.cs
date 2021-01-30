using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Datal
{
    public class Parent
    {
        [Key]
        public int JobId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        public bool ParentApproval { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public Guid OwnerId { get; set; }
    }
}
