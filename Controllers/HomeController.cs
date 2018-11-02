using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyncfusionWebComponents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var DataSource = TagData.GetData();
            ViewBag.datasource = DataSource;
            var Order = OrdersDetails.GetAllRecords();
            ViewBag.gridData = Order;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class WebsiteCollection
        {
            public string text { get; set; }
            public string url { get; set; }
            public int frequency { get; set; }
        }

        public class TagData
        {
            public static List<WebsiteCollection> GetData()
            {
                List<WebsiteCollection> sites = new List<WebsiteCollection>();
                
                sites.Add(new WebsiteCollection { text = "Google", url = "http://tech.firstpost.com/tag/google", frequency = 12 });
                sites.Add(new WebsiteCollection { text = "Apple", url = "http://tech.firstpost.com/tag/apple-iwork", frequency = 3 });
                sites.Add(new WebsiteCollection { text = " Drone ", url = "http://tech.firstpost.com/tag/drone", frequency = 8 });
                sites.Add(new WebsiteCollection { text = "google Drone", url = "http://tech.firstpost.com/tag/google-drones/", frequency = 2 });
                sites.Add(new WebsiteCollection { text = "apple iwork", url = "http://tech.firstpost.com/tag/apple-iwork", frequency = 12 });
                sites.Add(new WebsiteCollection { text = "tech-buzz", url = "http://tech.firstpost.com/tag/tech-buzz", frequency = 5 });
                sites.Add(new WebsiteCollection { text = "netizens", url = "http://tech.firstpost.com/tag/netizens", frequency = 8 });
                sites.Add(new WebsiteCollection { text = "selfile", url = "http://tech.firstpost.com/tag/selfie", frequency = 20 });
                sites.Add(new WebsiteCollection { text = "globalselfile", url = "http://tech.firstpost.com/tag/nasa-globalselfie", frequency = 1 });
                sites.Add(new WebsiteCollection { text = "extreme", url = "http://www.extremetech.com/", frequency = 3 });
                sites.Add(new WebsiteCollection { text = "at-t move", url = "http://www.extremetech.com/extreme/182815-att-moves-to-acquire-directv-to-defend-against-comcast-everyone-loses", frequency = 5 });
                sites.Add(new WebsiteCollection { text = "Gearlog", url = "http://www.gearlog.com/", frequency = 9 });
                sites.Add(new WebsiteCollection { text = "Information Week", url = "http://www.informationweek.com/", frequency = 0 });
                sites.Add(new WebsiteCollection { text = "PCWorld", url = "http://www.pcworld.com/", frequency = 11 });
                sites.Add(new WebsiteCollection { text = "Tech Republic", url = "http://techrepublic.com/", frequency = 3 });
                sites.Add(new WebsiteCollection { text = "Valleywag", url = "http://valleywag.gawker.com/", frequency = 6 });
                sites.Add(new WebsiteCollection { text = "computing", url = "http://www.extremetech.com/category/computing", frequency = 9 });
                sites.Add(new WebsiteCollection { text = "WebProNews", url = "http://www.webpronews.com/", frequency = 2 });
                return sites;

            }
        }

        public class OrdersDetails
        {
            public OrdersDetails()
            {

            }
            public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
            {
                this.OrderID = OrderID;
                this.CustomerID = CustomerId;
                this.EmployeeID = EmployeeId;
                this.Freight = Freight;
                this.ShipCity = ShipCity;
                this.Verified = Verified;
                this.OrderDate = OrderDate;
                this.ShipName = ShipName;
                this.ShipCountry = ShipCountry;
                this.ShippedDate = ShippedDate;
                this.ShipAddress = ShipAddress;
            }
            public static List<OrdersDetails> GetAllRecords()
            {
                List<OrdersDetails> order = new List<OrdersDetails>();
                int code = 10000;
                for (int i = 1; i < 10; i++)
                {
                    order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                    order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                    order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
                    order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                    order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                    code += 5;
                }
                return order;
            }

            public int? OrderID { get; set; }
            public string CustomerID { get; set; }
            public int? EmployeeID { get; set; }
            public double? Freight { get; set; }
            public string ShipCity { get; set; }
            public bool Verified { get; set; }
            public DateTime OrderDate { get; set; }

            public string ShipName { get; set; }

            public string ShipCountry { get; set; }

            public DateTime ShippedDate { get; set; }
            public string ShipAddress { get; set; }
        }

    }
}