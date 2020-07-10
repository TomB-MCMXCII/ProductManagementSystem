using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProductManegement.Core.Models
{
    public class ProjectAudit
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime TimeOfChange {get;set;}
        
    }
}
