using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Repositories.ServiceClient.Model
{
    public class GYRData
    {
        public string id { get; set; }
        public ConfigProperties configProperties { get; set; }
        public string name { get; set; }
    }
    public class ConfigProperties
    {
        public List<GyrRange> gyrRange { get; set; }
    }
    public class GyrRange
    {
        public string red { get; set; }
        public string green { get; set; }
        public string yellow { get; set; }
    }
}
