using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;


namespace ggak_final_project.Models
{
    public class WayPoint
    {
        public int Id { get; set; }
        public DbGeometry Coordinate { get; set; }
        public String URL { get; set; }
     
    }
}