using QuanLiSinhVien.DataAccessLayer;
using QuanLiSinhVien.Models;
using QuanLiSinhVien.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSinhVien.Controllers
{
    public class KetQuaController : Controller
    {
        private readonly ISinhVienDao _sinhvienDao;
        private readonly IKetQuaDao _ketquaDao;
        private readonly IMonHocDao _monhocDao;
        public KetQuaController()
        {
            _sinhvienDao = new SinhVienDaoImpl();
            _ketquaDao = new KetQuaDaoImpl();
            _monhocDao = new MonHocDaoImp();
        }
        public KetQuaController(ISinhVienDao _sinhvienDao, IKetQuaDao _ketquaDao, IMonHocDao _monhocDao)
        {
            this._sinhvienDao = _sinhvienDao;
            this._ketquaDao = _ketquaDao;
            this._monhocDao = _monhocDao;
        }
        // GET: KetQua
        public ActionResult Filter()
        {
            ViewBag.MonHoc = selectMonHocs();
            var lstKetQua = _ketquaDao.GetAllKetQuaDangHoc();
            List<KetQuaDetail> lstKetQuaDetail = new List<KetQuaDetail>();
            foreach (var ketqua in lstKetQua)
            {
                var monHoc = _monhocDao.getMonHocByID(ketqua.KetQuaID.MaMH);
                var sinhVien = _sinhvienDao.GetSinhVienByMaSV(ketqua.KetQuaID.MaSV);
                lstKetQuaDetail.Add(new KetQuaDetail(sinhVien, monHoc, sinhVien.MaSV, monHoc.MaMH, ketqua.DQT, ketqua.DTP, ketqua.DiemTong, ketqua.TrangThai));
            }
            return View(lstKetQuaDetail);
        }

        public ActionResult FilterByMaMH(string MaMH)
        {
            ViewBag.MonHoc = selectMonHocs();
            ViewBag.MaMH = MaMH;
            List<KetQua> lstKetQua;
            if (MaMH == null || MaMH == "All") lstKetQua = _ketquaDao.GetAllKetQuaDangHoc();
            else lstKetQua = _ketquaDao.GetAllKetQuaDangHocByMaMH(MaMH);
            List<KetQuaDetail> lstKetQuaDetail = new List<KetQuaDetail>();
            foreach (var ketqua in lstKetQua)
            {
                var monHoc = _monhocDao.getMonHocByID(ketqua.KetQuaID.MaMH);
                var sinhVien = _sinhvienDao.GetSinhVienByMaSV(ketqua.KetQuaID.MaSV);
                lstKetQuaDetail.Add(new KetQuaDetail(sinhVien, monHoc, sinhVien.MaSV, monHoc.MaMH, ketqua.DQT, ketqua.DTP, ketqua.DiemTong, ketqua.TrangThai));
            }
            return PartialView("_KetQuaPartialView", lstKetQuaDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(List<KetQuaNotKey> lstKetQua)
        {
            if (ModelState.IsValid)
            {
                if (lstKetQua != null)
                {
                    foreach (var ketQua in lstKetQua)
                    {
                        //Console.WriteLine(ketQua);
                        if (ketQua.DQT != null && ketQua.DTP != null)
                        {
                            var monHoc = _monhocDao.getMonHocByID(ketQua.MaMH);
                            ketQua.DiemTong = (monHoc.TiLeDQT * ketQua.DQT + monHoc.TiLeDTP * ketQua.DTP) / (monHoc.TiLeDQT + monHoc.TiLeDTP);
                            if (ketQua.DiemTong >= 4) ketQua.TrangThai = "Qua môn";
                            else ketQua.TrangThai = "Trượt";
                        }
                        _ketquaDao.update(ketQua);
                    }
                }
            }
            return RedirectToAction("Filter");
        }

        private List<SelectListItem> selectMonHocs()
        {
            List<SelectListItem> items = new List<SelectListItem> ();
            var lstMonHoc = _monhocDao.getAllMonHocs();
            foreach(var monHoc in lstMonHoc)
            {
                items.Add(new SelectListItem
                {
                    Text = monHoc.TenMon,
                    Value = monHoc.MaMH
                });
            }
            return items;
        }
    }
}