using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Models
{
    public class ContractorDelete
    {
        [Required]
        public int JobId { get; set; }
    }
}
