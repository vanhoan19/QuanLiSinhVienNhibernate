using NHibernate.Criterion;
using QuanLiSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.DataAccessLayer
{
    public class SinhVienDaoImpl : DaoProviderBase<SinhVien, string>, ISinhVienDao
    {
        public List<SinhVien> GetAllSinhVien()
        {
            return base.GetAll();
        }

        public List<SinhVien> GetAllSinhVienByMaSVOrTenSV(string text)
        {
            var icriteria = base._currentNHibernateSession.CreateCriteria(typeof(SinhVien));
            icriteria.Add(Restrictions.Disjunction()
                .Add(Restrictions.Like("MaSV", $"%{text}%"))
                .Add(Restrictions.Like("TenSV", $"%{text}%"))
            );
            return icriteria.List<SinhVien>().ToList();
        }

        public SinhVien GetSinhVienByMaSV(string maSV)
        {
            return base.GetObjectByID(maSV);
        }
    }
}