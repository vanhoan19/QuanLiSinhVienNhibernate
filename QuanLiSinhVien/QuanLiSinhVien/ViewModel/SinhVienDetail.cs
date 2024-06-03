using QuanLiSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.ViewModel
{
    public class SinhVienDetail
    {
        public SinhVienDetail(SinhVien sinhVien, List<KetQuaDetail> lstKetQua, List<MonHoc> lstMonHoc)
        {
            this.sinhVien = sinhVien;
            this.lstKetQua = lstKetQua;
            this.lstMonHoc = lstMonHoc;
        }

        public SinhVien sinhVien { get; set; } // Sinh viên hiện tại
        public List<KetQuaDetail> lstKetQua { get; set; } // Danh sách các môn đã đăng kí và kết quả
        public List<MonHoc> lstMonHoc { get; set; } // Các môn chưa đăng kí
    }
}