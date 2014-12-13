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
        public int Id { get; set; } //shouldn't be able to set!!!!!!!! make private set
        public float Lat { get; set; }
        public float Long { get; set; }
     //will later put in path ID, but it will be a relationship
        public String URL { get; set; }
     
    }
}