using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            Response.StatusCode = 404;
            ViewBag.uri = Request.Url.ToString().Split(';')[1];
            ViewBag.method = Request.HttpMethod;

            return View();
        }
    }
}