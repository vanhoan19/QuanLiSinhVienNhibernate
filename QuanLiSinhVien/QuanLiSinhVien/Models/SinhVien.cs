using NHibernate.SqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.Models
{
    public class SinhVien
    {
        public virtual string MaSV { get; set; }
        public virtual string TenSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual string Lop { get; set; }
        public virtual int Khoa { get; set; }
    }
}