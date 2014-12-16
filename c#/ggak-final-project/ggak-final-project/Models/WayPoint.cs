using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Microsoft.Ajax.Utilities;


namespace ggak_final_project.Models
{
    public class WayPoint
    {
        public int Id { get; set; } //shouldn't be able to set!!!!!!!! make private set
        //public float Lat { get; set; }
        //public float Lng { get; set; }
        [DataMember(Name = "Lat")]
        //[Required]
        public float Latitude { get; set; }
        [DataMember(Name = "Lng")]
        //[Required]
        public float Longitude { get; set; }
     //will later put in path ID, but it will be a relationship
        //[Required]
        public String URL { get; set; }
        public int Order { get; set; }
     
    }
}