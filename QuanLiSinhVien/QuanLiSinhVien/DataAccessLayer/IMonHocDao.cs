using QuanLiSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataAccessLayer
{
    public interface IMonHocDao
    {
        List<MonHoc> getAllMonHocs();
        MonHoc getMonHocByID(string MaMH);
    }
}
