using Microsoft.Ajax.Utilities;
using QuanLiSinhVien.DataAccessLayer;
using QuanLiSinhVien.Models;
using QuanLiSinhVien.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLiSinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ISinhVienDao _sinhvienDao;
        private readonly IKetQuaDao _ketquaDao;
        private readonly IMonHocDao _monhocDao;
        public SinhVienController()
        {
            _sinhvienDao = new SinhVienDaoImpl();
            _ketquaDao = new KetQuaDaoImpl();
            _monhocDao = new MonHocDaoImp();
        }
        public SinhVienController(ISinhVienDao _sinhvienDao, IKetQuaDao _ketquaDao, IMonHocDao _monhocDao)
        {
            this._sinhvienDao = _sinhvienDao;
            this._ketquaDao = _ketquaDao;
            this._monhocDao = _monhocDao;
        }
        const int PageSize = 10;
        public ActionResult Index()
        {
            //ViewBag.ConnectString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            List<SinhVien> lstSinhVien = _sinhvienDao.GetAllSinhVien();
            ViewBag.PageNum = (int) Math.Ceiling(lstSinhVien.Count * 1.0 / PageSize);
            ViewBag.CurrentPage = 1;
            return View(lstSinhVien.GetRange(0, PageSize));
        }
        public ActionResult Details(string MaSV)
        {
            SinhVien sinhVien = _sinhvienDao.GetSinhVienByMaSV(MaSV);
            List<KetQua> lstKetQua = _ketquaDao.GetAllKetQuaByMaSV(MaSV);
            List<MonHoc> lstMonHoc = _monhocDao.getAllMonHocs();

            List<KetQuaDetail> lstKetQuaDetail = new List<KetQuaDetail>();
            foreach (var ketqua in lstKetQua)
            {
                var monHoc = _monhocDao.getMonHocByID(ketqua.KetQuaID.MaMH);
                lstMonHoc.Remove(monHoc);
                lstKetQuaDetail.Add(new KetQuaDetail(sinhVien, monHoc, sinhVien.MaSV, monHoc.MaMH, ketqua.DQT, ketqua.DTP, ketqua.DiemTong, ketqua.TrangThai));
            }
            ViewBag.MaSV = sinhVien.MaSV;
            return View(new SinhVienDetail(sinhVien, lstKetQuaDetail, lstMonHoc));
        }
        public ActionResult PageSinhVien(int? page, string textSearch)
        {
            if (page == null) page = 1;
            if (textSearch == null) textSearch = string.Empty;
            List<SinhVien> lstSinhVien = _sinhvienDao.GetAllSinhVienByMaSVOrTenSV(textSearch);
            ViewBag.PageNum = (int)Math.Ceiling(lstSinhVien.Count * 1.0 / PageSize) > 0 ? (int)Math.Ceiling(lstSinhVien.Count * 1.0 / PageSize) : 1;
            ViewBag.CurrentPage = page;
            List<SinhVien> lstSinhVienSelected = new List<SinhVien>();
            if (lstSinhVien != null)
            {
                if (page == ViewBag.PageNum) lstSinhVienSelected = lstSinhVien.GetRange((int)((page - 1) * PageSize), (int)(lstSinhVien.Count - (page - 1) * PageSize));
                else lstSinhVienSelected = lstSinhVien.GetRange((int)(page - 1) * PageSize, PageSize);
            }
            return PartialView("_SinhVienPartialView", lstSinhVienSelected);
        }
        public ActionResult Update(string MaSV, string MaMH) 
        {
            var ketQua = new KetQuaNotKey(MaSV, MaMH, null, null, null, "Đang học");
            _ketquaDao.insert(ketQua);
            return RedirectToAction("Details", new { MaSV = MaSV});
        }

    }
}