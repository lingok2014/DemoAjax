using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Data;
using Demo.Data.Model;


namespace Demo.Web.Controllers
{
    public class NhanVienController : Controller
    {


        private NhanVienDbContext db;
        public NhanVienController()
        {
            db = new NhanVienDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEmployee()
        {
            var result = db.NhanVien.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetId(int? id)
        {
            var result = db.NhanVien.ToList().Find(x => x.Id == id);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien.Add(nhanvien);
                db.SaveChanges();
            }
            return Json(nhanvien, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //NhanVien spUpdate = db.NhanVien.Find(nhanvien.ID);
                //if (spUpdate != null)
                //{
                //    spUpdate.TenNhanVien = nhanvien.TenNhanVien;
                //    spUpdate.SoDienThoai = nhanvien.SoDienThoai;
                //    spUpdate.DiaChi = nhanvien.DiaChi;
                //    spUpdate.Email = nhanvien.Email;
                //    spUpdate.Tuoi = nhanvien.Tuoi;

                //    db.SaveChanges();

                //}
            }
            return Json(nhanvien, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public ActionResult Delete(int  id)
        {
            var nhanvien = db.NhanVien.ToList().Find(m => m.Id == id);
            if (nhanvien != null)
            {
                db.NhanVien.Remove(nhanvien);
                db.SaveChanges();
            }

            return Json(nhanvien, JsonRequestBehavior.AllowGet);
        }
    }
}