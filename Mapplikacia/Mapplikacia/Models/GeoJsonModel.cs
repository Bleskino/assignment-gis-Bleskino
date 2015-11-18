using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class GeoJsonModel
    {
        public string type { get; set; }
        public GeoJsonProperties properties { get; set; }
        public GeoJsonGeometry geometry { get; set; }
    }
}