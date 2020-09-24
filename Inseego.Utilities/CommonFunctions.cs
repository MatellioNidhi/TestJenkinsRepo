using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inseego.Utilities
{
    public static class CommonFunctions
    {
        public static string ConvertDistance(long value)
        {
            long calculatedValue = 0;
            calculatedValue = value / 1000;
            return Convert.ToString(calculatedValue) + " km";
        }

        public static long ConvertDistanceToKm(long value)
        {
            long calculatedValue = value / 1000;
            return calculatedValue;
        }

        public static string ConvertTime(long sec)
        {
            if (sec == null || sec == 0)
            {
                return "00:00:00";
            }
            // convert the seconds into hours,seconds and minutes
            var totalSeconds = sec;
            var hours = Math.Floor((decimal)(totalSeconds / 3600));
            totalSeconds %= 3600;
            var minutes = Math.Floor((decimal)(totalSeconds / 60));
            var seconds = totalSeconds % 60;
            // If you want strings with leading zeroes:
            string strhr = Convert.ToString(hours);
            string strmin = Convert.ToString(minutes);
            string strsec = Convert.ToString(seconds);

            if (minutes >= 0 && minutes < 10)
            {
                strmin = Convert.ToString(minutes).PadLeft(2, '0');
            }
            if (hours >= 0 && hours < 10)
            {
                strhr = Convert.ToString(hours).PadLeft(2, '0');
            }
            if (seconds >= 0 && seconds < 10)
            {
                strsec = Convert.ToString(seconds).PadLeft(2, '0');
            }
            //////console.log(hours + ":" + minutes + ":" + seconds);
            return strhr + ":" + strmin + ":" + strsec;
        }

        public static void GetFilteredDates(string filterType, DateTime fromDate, DateTime toDate, out DateTime preFromDate, out DateTime preTodate)
        {
            preFromDate = fromDate;
            preTodate = toDate;
            int dayDiff = 0;
            switch (filterType.ToLower())
            {
                case "year":
                    preTodate = fromDate.AddDays(-1);
                    preFromDate = fromDate.AddYears(-1);
                    break;
                case "quarter":
                    preTodate = fromDate.AddDays(-1);
                    preFromDate = fromDate.AddMonths(-3);
                    break;
                case "month":
                    preTodate = fromDate.AddDays(-1);
                    preFromDate = fromDate.AddMonths(-1);
                    break;
                case "week":
                    preTodate = fromDate.AddDays(-1);
                    preFromDate = fromDate.AddDays(-7);
                    break;
                case "day":
                    dayDiff = Convert.ToInt32((toDate - fromDate).TotalDays);
                    preTodate = fromDate.AddDays(-1);
                    preFromDate = preTodate.AddDays(-dayDiff);
                    break;
                case "range":
                    dayDiff = Convert.ToInt32((toDate - fromDate).TotalDays);
                    preTodate = fromDate.AddDays(-1);
                    preFromDate = preTodate.AddDays(-dayDiff);
                    break;
            }

        }

        public static string ChangeCase(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, "[A-Z]", " $0").Trim();
        }
        public static string ChangeTitle(string title)
        {
            string titleCase = title;
            switch (title.ToLower())
            {
                case "hacount":
                case "totalha":
                    titleCase = "Harsh Acceleration";
                    break;

                case "hbcount":
                case "totalhb":
                    titleCase = "Harsh Braking";
                    break;

                case "cdcount":
                case "totalcd":
                    titleCase = "Continuous Driving";
                    break;


                case "oscount":
                case "totalos":
                    titleCase = "Overspeeding";
                    break;

                case "hccount":
                case "totalhc":
                    titleCase = "Harsh Cornering";
                    break;

                case "ndcount":
                case "totalnd":
                    titleCase = "Night Driving";
                    break;
            }
            return titleCase;

        }

        public static decimal DistanceByUnit(string unit)
        {
            decimal distance = 1609.34M;
            switch (unit.ToLower())
            {
                case "km":
                    distance = 1000;
                    break;
                case "miles":
                    distance = 1609.34M;
                    break;
            }
            return distance;
        }

        public static double StandardDeviation(double[] data, out double mean, out double total)
        {
            double stddev = 0;
            mean = Math.Round(data.Average(x => x), 2);
            total = Math.Round(data.Sum(x => x), 2);
            double x1 = mean;
            double[] dataitem = data.Select(x => Math.Pow((x - x1), 2)).ToArray();
            stddev = dataitem.Average(x => x);
            stddev = Math.Round(Math.Sqrt(stddev), 2);
            return stddev;
        }

        public static string TimeFormateHHMMSS(this decimal TimesInSecond, string TimeFormate)
        {
            string strhr = "00";
            string strmin = "00";
            string strsec = "00";
            string TimeInFormate = "";
            if (TimesInSecond > 0)
            {
                var totalSeconds = TimesInSecond;

                long hours = Convert.ToInt64(Math.Floor((decimal)(totalSeconds / 3600)));
                totalSeconds %= 3600;
                long minutes = Convert.ToInt64(Math.Floor((decimal)(totalSeconds / 60)));
                long seconds = Convert.ToInt64(totalSeconds % 60);
                strhr = (hours >= 0 && hours < 10) ? "0" + Convert.ToString(hours) : Convert.ToString(hours);
                strmin = (minutes >= 0 && minutes < 10) ? "0" + Convert.ToString(minutes) : Convert.ToString(minutes);
                strsec = (seconds >= 0 && seconds < 10) ? "0" + Convert.ToString(seconds) : Convert.ToString(seconds);
            }
            switch (TimeFormate)
            {
                case "HH:mm":
                    TimeInFormate = strhr + ":" + strmin;
                    break;
                case "mm:HH":
                    TimeInFormate = strmin + ":" + strhr;
                    break;
                default:
                    TimeInFormate = strhr + ":" + strmin + ":" + strsec;
                    break;
            }
            return TimeInFormate;
        }

        public static void HeaderDataComparsion(decimal currentValue, decimal oldValue, out string value, out string icon, out string color)
        {
            decimal diffInPercent;
            // Calculating the differance by comparing the values
            value = "0";
            icon = "neutral";
            color = "yellow";
            decimal diff = currentValue - oldValue;

            if (diff == 0)
            {
                diffInPercent = 0;
                value = Math.Round(diffInPercent, 2).ToString();
                icon = "neutral";
                color = "yellow";
            }
            else if (oldValue > currentValue)
            {
                diffInPercent = currentValue == 0 ? 100 : diff * 100 / oldValue;
                value = Math.Round(Math.Abs(diffInPercent), 2).ToString();
                icon = "down";
                color = "green";
            }
            else if (currentValue > oldValue)
            {
                diffInPercent = oldValue == 0 ? 100 : diff * 100 / oldValue;
                value = Math.Round(Math.Abs(diffInPercent), 2).ToString();
                icon = "up";
                color = "red";
            }
        }

        // Creating the function for returning the color type Green for progress in upside and Color Red for downside progress
        public static void HeaderDataComparsionFreenForUp(decimal currentValue, decimal oldValue, out string value, out string icon, out string color)
        {
            decimal diffInPercent;

            // Calculating the differance by comparing the values
            value = "0";
            icon = "neutral";
            color = "yellow";

            decimal diff = currentValue - oldValue;

            if (diff == 0)
            {
                diffInPercent = 0;
                value = Math.Round(diffInPercent, 2).ToString();
                icon = "neutral";
                color = "yellow";
            }
            else if (oldValue > currentValue)
            {
                diffInPercent = currentValue == 0 ? 100 : diff * 100 / oldValue;
                value = Math.Round(Math.Abs(diffInPercent), 2).ToString();
                icon = "down";
                color = "red";
            }
            else if (currentValue > oldValue)
            {
                diffInPercent = oldValue == 0 ? 100 : diff * 100 / oldValue;
                value = Math.Round(Math.Abs(diffInPercent), 2).ToString();
                icon = "up";
                color = "green";
            }
        }

        public static object CopyProperties(object objSource, object objDestination)
        {
            //get the list of all properties in the destination object
            var destProps = objDestination.GetType().GetProperties();

            //get the list of all properties in the source object
            foreach (var sourceProp in objSource.GetType().GetProperties())
            {
                foreach (var destProperty in destProps)
                {
                    //if we find match between source & destination properties name, set
                    //the value to the destination property
                    if (destProperty.Name == sourceProp.Name &&
                            destProperty.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                    {
                        //destProperty.SetValue(destProps, sourceProp.GetValue(sourceProp, new object[] { }), new object[] { });
                        destProperty.SetValue(objDestination, sourceProp.GetValue(objSource));
                        break;
                    }
                }
            }

            return objDestination;
        }
    }
}
