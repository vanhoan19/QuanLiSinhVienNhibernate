using NHibernate.Criterion;
using QuanLiSinhVien.Models;
using QuanLiSinhVien.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVien.DataAccessLayer
{
    public class KetQuaDaoImpl : DaoProviderBase<KetQua, KetQuaCompositeKey>, IKetQuaDao
    {
        public List<KetQua> GetAllKetQuaDangHocByMaMH(string MaMH)
        {
            var icriteria = base._currentNHibernateSession.CreateCriteria(typeof(KetQua));
            icriteria.Add(Restrictions.Eq("KetQuaID.MaMH", MaMH));
            icriteria.Add(Restrictions.Eq("TrangThai", "Đang học"));
            return icriteria.List<KetQua>().ToList();
        }

        public List<KetQua> GetAllKetQuaByMaSV(String MaSV)
        {
            var icriteria = base._currentNHibernateSession.CreateCriteria(typeof(KetQua));
            icriteria.Add(Restrictions.Eq("KetQuaID.MaSV", MaSV));
            return icriteria.List<KetQua>().ToList();
        }

        public List<KetQua> GetAllKetQuaDangHoc()
        {
            var icriteria = base._currentNHibernateSession.CreateCriteria(typeof(KetQua));
            icriteria.Add(Restrictions.Eq("TrangThai", "Đang học"));
            return icriteria.List<KetQua>().ToList();
        }

        public void update(KetQuaNotKey KetQua)
        {
            base.Update(new KetQua(KetQua));
        }

        public void insert(KetQuaNotKey KetQua)
        {
            base.Create(new KetQua(KetQua));
        }
    }
}