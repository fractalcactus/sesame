using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ggak_final_project.Controllers.business_logic
{
    public class Radius
    {



         private double radiusThreshold; //fraction of a degree

        public Radius()
        {
            radiusThreshold = 0.0001;
        }

        public Radius(double radiusThreshold) //This threshold is in degrees of Latitude & Longitude
        {
            this.radiusThreshold = radiusThreshold;
        }

        private double accuracy { get { return radiusThreshold / 100.0; } } //1% of the threshold

        private double Pythag(double pointOne, double pointTwo)
        {
            double sides = (Math.Pow(pointOne, 2)) + (Math.Pow(pointTwo, 2));
            double answer = Math.Sqrt(sides);
            return answer;
        }

        public Boolean isInRadius(double wayPointLat, double wayPointLong, double userLat, double userLong)
        {

            double largerLat;
            double smallerLat;

            double largerLong;
            double smallerlong;

            if (wayPointLat > userLat)
            {
                largerLat = wayPointLat;
                smallerLat = userLat;
            }
            else
            {
                largerLat = userLat;
                smallerLat = wayPointLat;
            }
            if (wayPointLong > userLong)
            {
                largerLong = wayPointLong;
                smallerlong = userLong;
            }
            else
            {
                largerLong = userLong;
                smallerlong = wayPointLong;
            }


            double latDelta = (largerLat - smallerLat);
            double longDelta = (largerLong - smallerlong);
            return Pythag(latDelta, longDelta) < (radiusThreshold + accuracy);


        }












    }
}