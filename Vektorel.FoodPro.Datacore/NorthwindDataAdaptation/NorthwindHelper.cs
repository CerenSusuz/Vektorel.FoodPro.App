using SE.BASECORE.Data.Ado.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.FoodPro.Datacore.NorthwindDataAdaptation
{
    public class NorthwindHelper : BaseConnectionHelper
    {
        public NorthwindHelper()
        {
            ConnectionString = "Data Source=CEREN\\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=true;";
        }
    }
}
