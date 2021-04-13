using SE.BASECORE.Data.Ado.NET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.FoodPro.Datacore.NorthwindDataAdaptation;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.Business.NorthwindBO
{
    public class CategoryBO : IMainBO<Category>
    {
        NorthwindHelper helper = new NorthwindHelper();
        public bool Delete(int id)
        {
            string cmdText = "Delete from Categories where CategoryID=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public Category Get(int id)
        {
            Category s = new Category();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader reader = helper.GetData("Select * from Categories where CategoryID=@id", CommandType.Text, parameters);

            while (reader.Read())
            {
                s.CategoryName = reader[nameof(s.CategoryName)].ToString();
                s.Description = reader[nameof(s.Description)].ToString();
                s.Picture = reader[nameof(s.Picture)].ToString();
                s.CategoryID = Convert.ToInt32(reader[nameof(s.CategoryID)]);
            }
            return s;
        }

        public List<Category> GetList()
        {
            List<Category> Categories = new List<Category>();
            SqlDataReader reader = helper.GetData("Select * from Categories");
            while (reader.Read())
            {
                Category s = new Category();
                s.CategoryName = reader[nameof(s.CategoryName)].ToString();
                s.Description = reader[nameof(s.Description)].ToString();
                s.Picture = reader[nameof(s.Picture)].ToString();
                s.CategoryID = Convert.ToInt32(reader[nameof(s.CategoryID)]);
                Categories.Add(s);
            }

            return Categories;
        }

        public bool Insert(Category model)
        {
            string cmdText = "Insert into Categories (CategoryName,Description,Picture) values(@cName,@desc,@picture)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@cName",model.CategoryName),
                new SqlParameter("@desc",model.Description),
                new SqlParameter("@picture",model.Picture)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(Category model)
        {
            string cmdText = "Update Categories set CategoryName=@cName,Description=@desc,Picture=@picture where CategoryID=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@cName",model.CategoryName),
                new SqlParameter("@desc",model.Description),
                new SqlParameter("@picture",model.Picture),
                new SqlParameter("@id",model.CategoryID)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
    }
}
