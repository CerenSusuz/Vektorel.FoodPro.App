using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.FoodPro.Business.NorthwindBO;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.Web.UI.Controllers
{
    public class RegisterSController : Controller
    {
        // GET: RegisterS

        ShipperBO sbo = new ShipperBO();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(string CompanyName, string Phone)
        {
            Shipper s = new Shipper
            {
                CompanyName = CompanyName,
                Phone = Phone
            };
            sbo.Insert(s);
            return RedirectToAction("Index", "Shipper");
        }
       
        public ActionResult Delete(int id)
        {
            sbo.Delete(id);
            return RedirectToAction("Index", "Shipper");
        }
        
    }
}