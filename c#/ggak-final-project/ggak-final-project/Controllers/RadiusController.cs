using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ggak_final_project
{
    public class RadiusController
    {

        public Boolean pointRadius(double wayPointLat, double wayPointLong, double userLat, double userLong)
        {
            if (wayPointLat == (userLat - 0.001) && (wayPointLat == (userLat + 0.001)))
            {
                if ((wayPointLong == (userLong - 0.001)) && (wayPointLong == (userLong + 0.001)))
                {
                    return true;
                }
            }
            return false;
        }

       
    }
}