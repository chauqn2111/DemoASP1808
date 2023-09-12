using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MyCodeFirsApproachDemo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CustomerController : Controller
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang kh)
        {
            try
            {
                khachHangRepository.InsertKhachHang(kh);
                TempData["Message"] = "Tạo mới thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                TempData["Message"] = "Cập nhật thành công";
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
            return View();
        }

        // POST: CustomerController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, KhachHang kh)
        {
            try
            {
                khachHangRepository.DeleteKhachHang(id);
                TempData["Message"] = "Xoá thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Index(string searchString, int? page, string sortBy)
        {
            var khachHangList = khachHangRepository.GetKhachHangs(sortBy).ToPagedList(page ?? 1, 5);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                khachHangList = khachHangRepository.GetKhachHangByName(searchString, sortBy).ToPagedList(page ?? 1, 5);
            }
            //TempData["searchString"] = searchString;
            return View(khachHangList);
        }
        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> SelectedCatDelete)
        {
            khachHangRepository.DeleteSelectedKhachHang(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} thàng thành công";
            return RedirectToAction("Index");
        }
    }
}
