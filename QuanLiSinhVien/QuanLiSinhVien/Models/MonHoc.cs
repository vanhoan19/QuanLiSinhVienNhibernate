using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.Models
{
    public class MonHoc
    {
        public virtual string MaMH { get; set; }
        public virtual string TenMon { get; set; }
        public virtual int SoTiet { get; set; }
        public virtual int TiLeDTP { get; set; }
        public virtual int TiLeDQT { get; set; }
    }
}