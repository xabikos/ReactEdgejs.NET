using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ReactEdge.Sample.Mvc5.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            var result = await reactContext.GetHtml("Index", new { });
            ViewBag.Indx = result;
            return View();
        }

        public async Task<ActionResult> About()
        {
            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            var result = await reactContext.GetHtml("About", new { message = "Your application description page." });
            ViewBag.About = result;
            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";
            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            var result = await reactContext.GetHtml("Contact", new { message = "Your contact page." });
            ViewBag.Contact = result;
            return View();
        }
    }
}