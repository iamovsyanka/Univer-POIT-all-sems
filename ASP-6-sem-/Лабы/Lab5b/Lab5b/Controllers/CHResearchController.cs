using System;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab5b.Controllers
{
    public class CHResearchController : Controller
    {
        static DateTime date = DateTime.Now;

        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 5)]
        public string AD()
        {
            date = DateTime.Now;
            return $"{date}";
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 7, VaryByParam = "x;y")]
        public ActionResult AP()
        {
            var x = Request.QueryString.Get("x");
            var y = Request.QueryString.Get("y");

            date = DateTime.Now;
            return Content($"{date}: {x} - {y}");
        }
    }
}