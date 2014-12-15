using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggak_final_project.BusinessLogic
{
    public class Radius
    {
        private double radiusThreshold = 0.001; //fraction of a degree
        private double accuracy { get { return radiusThreshold / 100.0; } } //1% of the threshold

        private double Pythag(double pointOne, double pointTwo)
        {
            double sides = (Math.Pow(pointOne, 2)) + (Math.Pow(pointTwo, 2));
            double answer = Math.Sqrt(sides);
            return answer;
        }

        public Boolean AreTwoPointsClose(double wayPointLat, double wayPointLong, double userLat, double userLong)
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

            //    double latLessThreshold = latDelta - radiusThreshold;
            //    double longLessThreshold = longDelta - radiusThreshold;


            //    return (latLessThreshold < accuracy) && (longLessThreshold < accuracy);



            //if (accuracy > (Pythag(wayPointLat + userLat) - radiusThreshold) && (accuracy > (userLat - wayPointLat - radiusThreshold)))
            //{
            //    if (accuracy > (wayPointLong - userLong - radiusThreshold) && (accuracy > (userLong - wayPointLong - radiusThreshold)))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }


    }
}