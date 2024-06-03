using QuanLiSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataAccessLayer
{
    public interface ISinhVienDao
    {
        List<SinhVien> GetAllSinhVien();
        SinhVien GetSinhVienByMaSV(string maSV);
        List<SinhVien> GetAllSinhVienByMaSVOrTenSV(string text);
    }
}
