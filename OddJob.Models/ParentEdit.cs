using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Models
{
    public class ParentEdit
    {
        public bool ParentApproval { get; set; }
        public int JobId { get; set; }
        public int ParentId { get; set; }

    }
}
