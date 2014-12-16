using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ggak_final_project.Models
{
    public class Path
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WayPoint> WayPoints { get; set; } 
    }
}