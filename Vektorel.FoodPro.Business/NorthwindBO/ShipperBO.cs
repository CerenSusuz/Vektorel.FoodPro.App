using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE.BASECORE.Data.Ado.NET;
using Vektorel.FoodPro.Model.POCO;
using System.Data.SqlClient;
using Vektorel.FoodPro.Datacore.NorthwindDataAdaptation;
using System.Data;

namespace Vektorel.FoodPro.Business.NorthwindBO
{
    public class ShipperBO : IMainBO<Shipper>
    {
        NorthwindHelper helper = new NorthwindHelper();
        public bool Delete(int id)
        {
            string cmdText = "Delete from Shippers where ShipperID=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };
            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public Shipper Get(int id)
        {
            Shipper s = new Shipper();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader reader = helper.GetData("Select * from Shippers where ShipperID=@id", CommandType.Text, parameters);

            while (reader.Read())
            {
                s.CompanyName = reader["CompanyName"].ToString();
                s.Phone = reader["Phone"].ToString();
                s.ShipperID = Convert.ToInt32(reader["ShipperID"]);
            }
            return s;
        }

        public List<Shipper> GetList()
        {
            List<Shipper> shippers = new List<Shipper>();
            SqlDataReader reader = helper.GetData("Select * from Shippers");
            while (reader.Read())
            {
                Shipper s = new Shipper();
                s.ShipperID = Convert.ToInt32(reader["ShipperID"]);
                s.CompanyName = reader["CompanyName"].ToString();
                s.Phone = reader["Phone"].ToString();
                shippers.Add(s);
            }

            return shippers;
        }

        public bool Insert(Shipper model)
        {
            string cmdText = "Insert into Shippers (CompanyName,Phone) values(@cName,@phone)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@cName",model.CompanyName),
                new SqlParameter("@phone",model.Phone)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(Shipper model)
        {
            string cmdText = "Update Shippers set CompanyName=@cName,Phone=@phone where ShipperID=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName="@cName",
                    Value = model.CompanyName,
                },
                new SqlParameter("@phone",model.Phone),
                new SqlParameter("@id",model.ShipperID)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }
    }
}
