using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ProductManegement.Core.Models
{
    public class Session
    {
        public Guid uuid { get; set; }
        public User User { get; set; }
        public string SessionStart { get; set; }
        public void CreateId() => uuid = Guid.NewGuid();
    }
}
