using QuanLiSinhVien.Models;
using QuanLiSinhVien.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataAccessLayer
{
    public interface IKetQuaDao
    {
        List<KetQua> GetAllKetQuaByMaSV(String MaSV);
        List<KetQua> GetAllKetQuaDangHocByMaMH(String MaMH);
        List<KetQua> GetAllKetQuaDangHoc();
        void update(KetQuaNotKey KetQua);
        void insert(KetQuaNotKey KetQua);
    }
}
