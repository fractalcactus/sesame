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
        public int Id { get; set; } //shouldn't be able to set!!!!!!!!
        public DbGeometry Lat { get; set; }
        public DbGeometry Long { get; set; }
     //will later put in path ID, but it will be a relationship
        public String URL { get; set; }
     
    }
}