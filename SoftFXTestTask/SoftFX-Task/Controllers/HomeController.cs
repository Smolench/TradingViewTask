using System.Web.Mvc;

namespace SoftFXTestTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DatafeedURL = Request.Url.Scheme + "://" + Request.Url.Authority +
                    Request.ApplicationPath.TrimEnd('/') + "/api";
            return View();
        }
    }
}