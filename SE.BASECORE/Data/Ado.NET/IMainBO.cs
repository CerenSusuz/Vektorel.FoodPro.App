using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.BASECORE.Data.Ado.NET
{
    public interface IMainBO<T>
    {
        bool Delete(int id);
        bool Insert(T model);
        bool Update(T model);
        List<T> GetList();
        T Get(int id);
    }
}
