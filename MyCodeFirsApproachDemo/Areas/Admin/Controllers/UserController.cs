using AutomobileLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCodeFirsApproachDemo.Areas.Admin.Models;
using X.PagedList;

namespace MyCodeFirsApproachDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        INguoiDungRepository nguoiDungRepository = null;
        public UserController() => nguoiDungRepository = new NguoiDungRepository();
        // GET: UserController
        public ActionResult Index(int? page, string sortBy)
        {
            var nguoiDungList = nguoiDungRepository.GetNguoiDungs(sortBy).ToPagedList(page ?? 1,4);
            List<LoaiNguoiDung> list_NguoiDung = new List<LoaiNguoiDung>
            {
                new LoaiNguoiDung{Id=1,Name="Admin", Color="#ea1010a1"},
                new LoaiNguoiDung{Id=2,Name="Quản lý", Color="#4735b4b5"},
                new LoaiNguoiDung{Id=3,Name="Nhân Viên", Color ="#e2b410e8"}
            };
            ViewBag.LoaiNguoiDung = list_NguoiDung;
            return View(nguoiDungList);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
