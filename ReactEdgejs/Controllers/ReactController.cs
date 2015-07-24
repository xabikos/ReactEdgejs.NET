using EdgeJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactEdgejs.Controllers
{
    public class ReactController : Controller
    {
        // GET: React
        public ActionResult Index()
        {            
            var generatedScript = System.IO.File.ReadAllText(Server.MapPath("~/app/generated/server.bundle.js"));
            var edgeServer = System.IO.File.ReadAllText(Server.MapPath("~/app/edgeServer.js"));
            var final = generatedScript + edgeServer;
            var func = Edge.Func(final);
            var result = func(new { dataProps = new { name = "babis" }}).Result;
            ViewBag.PageContent = result;
            return View();
        }
    }
}