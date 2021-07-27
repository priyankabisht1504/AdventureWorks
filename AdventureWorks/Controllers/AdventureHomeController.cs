using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    public class AdventureHomeController : Controller
    {
        // GET: AdventureHome
        public ActionResult Index()
        {
            return View();
        }
    }
}