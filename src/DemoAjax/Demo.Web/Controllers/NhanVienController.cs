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
        /// <summary>
        /// Hàm trả về danh sách nhân viên
        /// </summary>
        /// <returns>List nhân viên</returns>
        [HttpGet]
        public ActionResult GetEmployee()
        {
            var result = db.NhanVien.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// lấy nhân viên theo mã
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>1 dòng dữ liệu</returns>
        public ActionResult GetId(int? id)
        {
            var result = db.NhanVien.ToList().Find(x => x.Id == id);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// tạo mới một nhân viên.
        /// Bind Exclude = "Id" ở đây có nghĩa là khi ta thêm mới một record
        /// thì mặc định phương thức Create sẽ bỏ qua giá trị của Id vì ở đây Id 
        /// đã thiết lập tự động tăng
        /// </summary>
        /// <param name="nhanvien"></param>
        /// <returns></returns>
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
        /// <summary>
        /// chỉnh sữa nhân viên
        /// </summary>
        /// <param name="nhanvien">nhanvien</param>
        /// <returns>1 nhân viên</returns>
        [HttpPost]
        public ActionResult Update(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
        
            }
            return Json(nhanvien, JsonRequestBehavior.AllowGet);


        }
        /// <summary>
        /// hàm xóa nhân viên
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns> 1 dòng</returns>
        [HttpPost]
        public ActionResult Delete(int?  id)
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