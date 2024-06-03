using QuanLiSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.DataAccessLayer
{
    public class MonHocDaoImp : DaoProviderBase<MonHoc, string>, IMonHocDao
    {
        public List<MonHoc> getAllMonHocs()
        {
            return base.GetAll();
        }

        public MonHoc getMonHocByID(string MaMH)
        {
            return base.GetObjectByID(MaMH);
        }
    }
}