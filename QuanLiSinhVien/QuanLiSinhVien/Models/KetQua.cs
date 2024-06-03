using QuanLiSinhVien.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.Models
{
    public class KetQua
    {
        public virtual KetQuaCompositeKey KetQuaID { get; set; }
        public virtual double? DQT { get; set; }
        public virtual double? DTP { get; set; }
        public virtual double? DiemTong { get; set; }
        public virtual string TrangThai { get; set; }
        public KetQua()
        {
            
        }

        public KetQua(KetQuaCompositeKey ketQuaID, double? dQT, double? dTP, double? diemTong, string trangThai)
        {
            KetQuaID = ketQuaID;
            DQT = dQT;
            DTP = dTP;
            DiemTong = diemTong;
            TrangThai = trangThai;
        }

        public KetQua(KetQuaNotKey ketQua)
        {
            KetQuaID = new KetQuaCompositeKey(ketQua.MaSV, ketQua.MaMH);
            DQT = ketQua.DQT;
            DTP = ketQua.DTP;
            DiemTong = ketQua.DiemTong;
            TrangThai = ketQua.TrangThai;
        }
    }
}