using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Utilities.Aspects
{
    public static class StaticDictionary
    {
        public enum Test
        {
            TotalIncidents = 1, Drivers = 2
        }

        public static Dictionary<int, (string, string)> RiskChartCategories()
        {
            var output = new Dictionary<int, (string, string)>()
            {
                // {id,(Display on UI, name from db)}
                {1,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.Distance","TripDistanceMetres")},
                {2,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.TripCount","TripCount")},
                {3,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.ExcessiveIdling","XICounts")},
                {4,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.HarshBreaking","HarshBrakingCounts")},
                {5,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.HarshAcceleration","HarshAccelerationCounts")},
                {6,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.HarshCornering","HarshCorneringCounts")},
                {7,("Dashboard.RiskyDriver.Data.RiskChart.Chart.Dictionary.Overspeeding","OverspeedingCounts")},
                //{8,("Driver Behaviour (HA+HB+HC)","DriverBehaviour")},
                //{9,("Total Incidents","TotalIncidents")},
                //{10,("Driver","Driver")}
            };
            return output;
        }

        public static Dictionary<int, string> RiskChartColors()
        {
            var output = new Dictionary<int, string>()
            {
                {1,"Red"},
                {2,"Yellow"},
                {3,"Green"},
                {4,"RedYellow"},
                {5,"RedGreen"},
                {6,"YellowGreen"},
                {7,"RedYellowGreen"}
            };
            return output;
        }

        public static Dictionary<string, string> LanguageCulture()
        {
            var output = new Dictionary<string, string>()
            {
                {"english","en"},
                {"dutch","nl"},
                {"french","fr"},
                {"german","de"}
            };
            return output;
        }
    }
}

