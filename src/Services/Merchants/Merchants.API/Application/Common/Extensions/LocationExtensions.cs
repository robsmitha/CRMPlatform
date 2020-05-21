using Merchants.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.API.Application.Common.Extensions
{
    public static class LocationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static bool WithinMiles(this BaseAddress @this, double lat1, double lon1, double mi)
        {
            if (lat1 == 0 || lon1 == 0 || mi == double.MaxValue) return true;
            return @this.HaversineDistance(lat1, lon1) <= mi;
        }

        /// <summary>
        /// Use Haversine Distance formula to calculate a distance between two points
        /// </summary>
        /// <param name="this"></param>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <returns></returns>
        public static double HaversineDistance(this BaseAddress @this, double lat1, double lon1)
        {
            var lat2 = @this.Latitude;
            var lon2 = @this.Longitude;
            var R = 3960;   //miles
            static double ToRadians(double angle) => Math.PI * angle / 180.0;
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * c;

        }
    }
}
