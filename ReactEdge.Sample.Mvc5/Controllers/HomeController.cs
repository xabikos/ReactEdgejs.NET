using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ReactEdge.Sample.Mvc5.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            var result = await reactContext.GetHtml("Index", new { });
            ViewBag.Jumb = result;
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
    }
}