using System;
using System.Globalization;
using ESMonitorWebApi.Models.District;

namespace ESMonitorWebApi.Common
{
    public class Global
    {
        public static string GetProjectType(int type)
        {
            if (type == 1)
            {
                return "商业地产";
            }

            return "";
        }

        public static int GetRate(double value)
        {
            if (value < 0.4)
            {
                return 0;
            }
            if (value > 0.4 && value < 1)
            {
                return 1;
            }
            return 2;
        }

        public static string GetConnString(string city)
        {
            switch (city)
            {
                case "上海":
                    return "ESMonitorWD";
                default:
                    return "ESMonitor";
            }
        }

        public static Cordinate ConvertToGdCordinate(double longitude, double latitude)
        {
            var pi = 3.14159265358979324 * 3000.0 / 180.0;

            var gdlong = longitude - 0.0065;
            var gdlat = latitude - 0.006;

            var z = Math.Sqrt(gdlong * gdlong + gdlat * gdlat) - 0.00002 * Math.Sin(gdlat * pi);

            var theta = Math.Atan2(gdlat, gdlong) - 0.000003 * Math.Cos(gdlong * pi);

            return new Cordinate()
            {
                Longitude = (z * Math.Cos(theta)).ToString(CultureInfo.InvariantCulture),
                Latitude = (z * Math.Sin(theta)).ToString(CultureInfo.InvariantCulture)
            };
        }
    }
}