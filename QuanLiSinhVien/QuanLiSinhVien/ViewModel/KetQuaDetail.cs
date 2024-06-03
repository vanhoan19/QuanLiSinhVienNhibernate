using QuanLiSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.ViewModel
{
    public class KetQuaDetail
    {
        public SinhVien sinhVien { get; set; }
        public MonHoc monHoc { get; set; }
        public string MaSV { get; set; }
        public string MaMH { get; set; }
        public double? DQT { get; set; }
        public double? DTP { get; set; }
        public double? DiemTong { get; set; }
        public string TrangThai { get; set; }

        public KetQuaDetail(SinhVien sinhVien, MonHoc monHoc, string maSV, string maMH, double? dQT, double? dTP, double? diemTong, string trangThai)
        {
            this.sinhVien = sinhVien;
            this.monHoc = monHoc;
            this.MaSV = maSV;
            this.MaMH = maMH;
            DQT = dQT;
            DTP = dTP;
            DiemTong = diemTong;
            TrangThai = trangThai;
        }
    }
}