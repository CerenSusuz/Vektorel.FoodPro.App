using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.Web.UI.Models.ViewModels
{
    public class TablesViewModel
    {
        public List<Shipper> Shippers { get; set; }
        public List<Category> Categories { get; set; }
    }
}