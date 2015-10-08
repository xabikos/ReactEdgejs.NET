using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ReactEdge.Sample.Mvc5.Controllers
{
    public class ReactController : Controller
    {
        // GET: React
        public async Task<ActionResult> RenderReact()
        {
            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            var result = await reactContext.GetHtml("Contact", new { });
            ViewBag.RawHtmlResult = result;
            return View("ReactView");
        }
    }
}