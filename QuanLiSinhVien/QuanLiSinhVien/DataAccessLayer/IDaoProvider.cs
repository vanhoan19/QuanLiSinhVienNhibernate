using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataAccessLayer
{
    public interface IDaoProvider<T, V> where T : new ()
        where V : class
    {
        T Create(T t);
        List<T> GetAll();
        T GetObjectByID(V v);
        void Update(T t);
    }
}
