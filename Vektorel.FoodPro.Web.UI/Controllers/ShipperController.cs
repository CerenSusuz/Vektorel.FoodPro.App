using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.FoodPro.Business.NorthwindBO;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.Web.UI.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
        public ActionResult Index()
        {
            ShipperBO sbo = new ShipperBO();
            var result = sbo.GetList();
            return View(result);
        }
    }
}