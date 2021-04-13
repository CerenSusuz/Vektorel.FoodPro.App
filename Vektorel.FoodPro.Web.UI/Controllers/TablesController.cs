using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.FoodPro.Business.NorthwindBO;
using Vektorel.FoodPro.Web.UI.Models.ViewModels;

namespace Vektorel.FoodPro.Web.UI.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Index()
        {
            ShipperBO sbo = new ShipperBO();
            CategoryBO cbo = new CategoryBO();
            var shippers = sbo.GetList();
            var categories = cbo.GetList();
            TablesViewModel tb = new TablesViewModel();
            tb.Shippers = shippers;
            tb.Categories = categories;
            return View(tb);
        }
    }
}