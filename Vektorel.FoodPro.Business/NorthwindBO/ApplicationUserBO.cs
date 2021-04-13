using SE.BASECORE.Data.Ado.NET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Vektorel.FoodPro.Datacore.NorthwindDataAdaptation;
using Vektorel.FoodPro.Model.POCO;

namespace Vektorel.FoodPro.Business.NorthwindBO
{
    public class ApplicationUserBO : IMainBO<ApplicationUser>
    {
        NorthwindHelper helper = new NorthwindHelper();
        public bool Delete(int id)
        {
            string cmdText = "Delete from ApplicationUser where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public ApplicationUser Get(int id)
        {
            ApplicationUser user = new ApplicationUser();
            string cmdText = "Select * from ApplicationUser where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id",id)
            };

            var reader = helper.GetData(cmdText, CommandType.Text, parameters);

            while (reader.Read())
            {
                user.FullName = reader[nameof(user.FullName)].ToString();
                user.UserName = reader[nameof(user.UserName)].ToString();
                user.Password = reader[nameof(user.Password)].ToString();
                user.Email = reader[nameof(user.Email)].ToString();
                user.Id = Convert.ToInt32(reader[nameof(user.Id)]);
            }

            return user;
        }

        public List<ApplicationUser> GetList()  
        {
            List<ApplicationUser> list = new List<ApplicationUser>();
            string cmdText = "Select * from ApplicationUser";

            var reader = helper.GetData(cmdText, CommandType.Text);

            while (reader.Read())
            {
                list.Add(new ApplicationUser
                {
                    Email = reader["Email"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Id = Convert.ToInt32(reader["Id"])
                });
            }

            return list;

        }

        public bool Insert(ApplicationUser model)
        {
            string cmdText = "Insert into ApplicationUser (UserName,Password,FullName,Email) values(@username,@password,@fullname,@email)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@password",model.Password),
                new SqlParameter("@fullname",model.FullName),
                new SqlParameter("@email",model.Email)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Update(ApplicationUser model)
        {
            string cmdText = "Update ApplicationUser set UserName=@username,Password=@password,FullName=@fullname,Email=@email where Id=@id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username",model.UserName),
                new SqlParameter("@password",model.Password),
                new SqlParameter("@fullname",model.FullName),
                new SqlParameter("@email",model.Email),
                new SqlParameter("@id",model.Id)
            };

            return helper.ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        public bool Login(string userName,string password)
        {
            bool result = false;
            try
            {
                var users = GetList();
                foreach (var user in users)
                {
                    if (user.UserName.ToLower() == userName.ToLower() && user.Password == password)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool ForgotPassword(string email)
        {
            bool result = false;

            var users = GetList();

            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("ceren199704@gmail.com", "Vektorel123.");

                    MailMessage msg = new MailMessage("ceren199704@gmail.com", email);
                    msg.Subject = "Forgot password";
                    msg.IsBodyHtml = true;
                    msg.Body = $"<h2> Şifreni mi unuttun cimcime?</h2> </br> Huysuzlanma küçük hanım. Al bakalım şifren ;) </br> Kullanıcı Adı : {user.UserName} </br> Şifre : {user.Password}";
                    client.Send(msg);
                    result = true;
                }
            }

            return result;
        }
    }
}
