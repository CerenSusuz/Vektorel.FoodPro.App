using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.FoodPro.Business.NorthwindBO;

namespace Vektorel.FoodPro.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        { 
            return View();
        }
    }
}