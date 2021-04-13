using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.FoodPro.Business.NorthwindBO;

namespace Vektorel.FoodPro.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryBO cbo = new CategoryBO();
            var result = cbo.GetList();
            return View(result);
        }
    }
}