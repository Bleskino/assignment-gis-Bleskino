using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;
using Web.Models;

namespace Mapplikacia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetAtmAll()
        {
            var atmList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT operator, ST_AsGeoJson(way) FROM planet_osm_point WHERE amenity = \'atm\' AND operator IS NOT NULL";
                        using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var atm = new GeoJsonModel();
                            atm.type = "Feature";
                            atm.properties = new GeoJsonProperties();
                            atm.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            atm.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            atm.properties.MarkerSymbol = "bank";
                            atm.properties.MarkerColor = "#AD42F5";
                            atm.properties.MarkerSize = "small";
                            atm.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            atmList.Add(atm);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = atmList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetShopsAll()
        {
            var shopList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT name, ST_AsGeoJson(way) FROM planet_osm_point WHERE shop = \'supermarket\' AND name IS NOT NULL";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var shop = new GeoJsonModel();
                            shop.type = "Feature";
                            shop.properties = new GeoJsonProperties();
                            shop.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            shop.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            shop.properties.MarkerSymbol = "shop";
                            shop.properties.MarkerColor = "#EB42DF";
                            shop.properties.MarkerSize = "small";
                            shop.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            shopList.Add(shop);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = shopList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetTescoAll()
        {
            var tescoList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT name, ST_AsGeoJson(way) FROM planet_osm_point WHERE shop='supermarket' AND lower(name)LIKE '%tesco%'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tesco = new GeoJsonModel();
                            tesco.type = "Feature";
                            tesco.properties = new GeoJsonProperties();
                            tesco.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            tesco.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            tesco.properties.MarkerSymbol = "shop";
                            tesco.properties.MarkerColor = "#FA1E1E";
                            tesco.properties.MarkerSize = "small";
                            tesco.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            tescoList.Add(tesco);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = tescoList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetTernoAll()
        {
            var ternoList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT name, ST_AsGeoJson(way) FROM planet_osm_point WHERE shop='supermarket' AND lower(name)LIKE '%terno%'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var terno = new GeoJsonModel();
                            terno.type = "Feature";
                            terno.properties = new GeoJsonProperties();
                            terno.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            terno.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            terno.properties.MarkerSymbol = "shop";
                            terno.properties.MarkerColor = "#F26D00";
                            terno.properties.MarkerSize = "small";
                            terno.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            ternoList.Add(terno);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = ternoList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetBillaAll()
        {
            var billaList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT name, ST_AsGeoJson(way) FROM planet_osm_point WHERE shop='supermarket' AND lower(name)LIKE '%billa%'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var billa = new GeoJsonModel();
                            billa.type = "Feature";
                            billa.properties = new GeoJsonProperties();
                            billa.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            billa.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            billa.properties.MarkerSymbol = "shop";
                            billa.properties.MarkerColor = "#FAE711";
                            billa.properties.MarkerSize = "small";
                            billa.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            billaList.Add(billa);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = billaList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetVubAll()
        {
            var vubList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT operator, ST_AsGeoJson(way) FROM planet_osm_point WHERE amenity='atm' AND lower(operator)LIKE '%vúb%'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vub = new GeoJsonModel();
                            vub.type = "Feature";
                            vub.properties = new GeoJsonProperties();
                            vub.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            vub.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            vub.properties.MarkerSymbol = "bank";
                            vub.properties.MarkerColor = "#4752ED";
                            vub.properties.MarkerSize = "small";
                            vub.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            vubList.Add(vub);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = vubList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetTatraAll()
        {
            var tatraList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT operator, ST_AsGeoJson(way) FROM planet_osm_point WHERE amenity='atm' AND lower(operator)LIKE '%tatra%'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tatra = new GeoJsonModel();
                            tatra.type = "Feature";
                            tatra.properties = new GeoJsonProperties();
                            tatra.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            tatra.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            tatra.properties.MarkerSymbol = "bank";
                            tatra.properties.MarkerColor = "#47B6ED";
                            tatra.properties.MarkerSize = "small";
                            tatra.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            tatraList.Add(tatra);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = tatraList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
        public ActionResult GetSporAll()
        {
            var sporList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT operator, ST_AsGeoJson(way) FROM planet_osm_point WHERE amenity='atm' AND lower(operator)LIKE '%sporite%'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var spor = new GeoJsonModel();
                            spor.type = "Feature";
                            spor.properties = new GeoJsonProperties();
                            spor.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            spor.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty; ;
                            spor.properties.MarkerSymbol = "bank";
                            spor.properties.MarkerColor = "#47ED87";
                            spor.properties.MarkerSize = "small";
                            spor.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(1));
                            sporList.Add(spor);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = sporList;

            return new JsonDotNetResult(geoJsonFeatures);
        }

        [HttpPost]
        public ActionResult GetAtmSupermarketInRadius(int radius)
        {
            var atmList = new List<GeoJsonModel>();

            using (var conn = new NpgsqlConnection())
            {
                conn.ConnectionString = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;DATABASE=pdtgis;HOST=localhost;USER ID=postgres;PASSWORD=mato777bleskino";
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format("SELECT x.operator,y.name,ST_AsGeoJson(x.way), ST_AsGeoJson(y.way), ST_Distance(Geography(x.way),Geography(y.way)) from planet_osm_point x, planet_osm_point y where(x.amenity = \'atm\' AND x.operator IS NOT NULL) AND(y.shop = \'supermarket\') AND ST_DWithin(Geography(x.way), Geography(y.way), {0})", radius);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var atm = new GeoJsonModel();
                            var shop = new GeoJsonModel();
                            atm.type = "Feature";
                            atm.properties = new GeoJsonProperties();
                            atm.properties.name = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            atm.properties.title = !reader.IsDBNull(0) ? reader.GetString(0) : String.Empty;
                            atm.properties.description = !reader.IsDBNull(4) ? reader.GetDouble(4).ToString() : String.Empty;
                            atm.properties.MarkerSymbol = "bank";
                            atm.properties.MarkerColor = "#FF0000";
                            atm.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(2));
                            atmList.Add(atm);

                            shop.type = "Feature";
                            shop.properties = new GeoJsonProperties();
                            shop.properties.name = !reader.IsDBNull(1) ? reader.GetString(1) : String.Empty;
                            shop.properties.title = !reader.IsDBNull(1) ? reader.GetString(1) : String.Empty;
                            shop.properties.description = !reader.IsDBNull(4) ? reader.GetDouble(4).ToString() : String.Empty;
                            shop.properties.MarkerSymbol = "shop";
                            shop.properties.MarkerColor = "#00FF00";
                            shop.geometry = JsonConvert.DeserializeObject<GeoJsonGeometry>(reader.GetString(3));
                            atmList.Add(shop);
                        }
                    }
                }
            }

            var geoJsonFeatures = new GeoJsonFeatureCollection();
            geoJsonFeatures.type = "FeatureCollection";
            geoJsonFeatures.features = atmList;

            return new JsonDotNetResult(geoJsonFeatures);
        }
    }
}