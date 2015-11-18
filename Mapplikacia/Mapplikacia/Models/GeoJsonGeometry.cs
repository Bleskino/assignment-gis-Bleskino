using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Web.Models
{
    public class GeoJsonGeometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
}