using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class GeoJsonFeatureCollection
    {
        public string type { get; set; }
        public List<GeoJsonModel> features { get; set; }
    }
}