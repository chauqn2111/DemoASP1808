using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using X.PagedList;

namespace MyCodeFirsApproachDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class CustomerController : BaseController
    {
        IKhachHangRepository khachHangRepository = null;
        public CustomerController() => khachHangRepository = new KhachHangRepository();

        // GET: CustomerController1
/*        [HttpGet]
        public ActionResult Index(string searchString)
        {
            //if (!String.IsNullOrEmpty(searchString))

            var khachHangList = khachHangRepository.GetKhachHangByName(searchString);
            return View(khachHangList);

            //return View();
        }*/

        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {
            var khachHangList = khachHangRepository.GetKhachHangByID(id);
            return View(khachHangList);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang kh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    khachHangRepository.InsertKhachHang(kh);
                    //TempData["Message"] = "Tạo mới thành công";
                    //TempData["AlertType"] = "alert-danger";
                    SetAlert("Tạo mới thành công", "error");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới khách hàng không thành công");
                }
            }
            catch
            {

            }
            return View(kh);
        }

        // GET: CustomerController1/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = khachHangRepository.GetKhachHangByID(id);
            return View(kh);
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KhachHang kh)
        {
            try
            {
                khachHangRepository.UpdateKhachHang(kh);
                SetAlert("Cập nhật thành công", "error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Delete/5
        public ActionResult Delete(int id)
        {
            var khachHangList = khachHangRepository.GetKhachHangByID(id);
            return View(khachHangList);
        }

        // POST: CustomerController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, KhachHang kh)
        {
            try
            {
                khachHangRepository.DeleteKhachHang(id);
                SetAlert("Xóa thành công", "error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeleteId(int id)
        {
            try
            {
                var record = khachHangRepository.GetKhachHangByID(id);
                if (record == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy bản ghi" });
                }
                khachHangRepository.DeleteKhachHang(id);
                SetAlert("Xoá thành công", "error");
                /*return Json(new { success = true, id = id});*/
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult Index(string searchString, string CityName , string sortBy, int? page)
        {
            //var khachHangList = khachHangRepository.GetKhachHangs(sortBy).ToPagedList(page ?? 1, 5);
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    searchString = searchString.ToLower();
            //    khachHangList = khachHangRepository.GetKhachHangByName(searchString, sortBy).ToPagedList(page ?? 1, 5);
            //}
            var khachHangList = khachHangRepository.GetKhachHangByName(searchString is null?null: searchString.ToLower(), sortBy, CityName is null ? null : CityName.ToLower()).ToPagedList(page ?? 1,5);
            //TempData["searchString"] = searchString;
            var citys = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text = "Đà Nẵng"},
                new SelectListItem {Value = "2", Text = "Quảng Nam"},
                new SelectListItem {Value = "3", Text = "HCM"},
                new SelectListItem {Value = "4", Text = "Hà Nội"},
                new SelectListItem {Value = "5", Text = "Hải Phòng"},
            };
            ViewBag.City = citys;
            return View(khachHangList);
        }
        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> SelectedCatDelete)
        {
            khachHangRepository.DeleteSelectedKhachHang(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} thàng thành công";
            return RedirectToAction("Index");
        }
        public JsonResult ListName(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                var data = khachHangRepository.GetKhachHangByName(q.ToLower(), "", "");
                var responseData = data.Select(kh => kh.TenKhachHang).ToList();
                return Json(new
                {
                    data = responseData,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
    }
}
