using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.FoodPro.Business.NorthwindBO;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.Web.UI.Controllers
{
    public class RegisterCController : Controller
    {
        // GET: RegisterC

        CategoryBO cbo = new CategoryBO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(string CategoryName, string Description, string Picture)
        {
            Category c = new Category
            {
                CategoryName = CategoryName,
                Description = Description,
                Picture = Picture
            };
            cbo.Insert(c);
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Delete(int id)
        {
            cbo.Delete(id);
            return RedirectToAction("Index", "Category");
        }
    }
}