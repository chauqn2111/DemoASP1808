﻿using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MyCodeFirsApproachDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,User")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class NhanVienController : BaseController
    {
        INhanVienRepository nhanVienRepository = null;
        public NhanVienController() => nhanVienRepository = new NhanVienRepository();
        // GET: NhanVienController1

        public ActionResult Index(string searchString, int? page, string sortBy)
        {
            var nhanVienList = nhanVienRepository.GetNhanViens(sortBy).ToPagedList(page ?? 1, 5);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                nhanVienList = nhanVienRepository.GetNhanVienByName(searchString, sortBy).ToPagedList(page ?? 1, 5);
            }
            //TempData["searchString"] = searchString;
            return View(nhanVienList);
        }

        // GET: NhanVienController1/Details/5
        public ActionResult Details(int id)
        {
            var nv = nhanVienRepository.GetNhanVienByID(id);
            return View(nv);
        }

        // GET: NhanVienController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVienController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nhanVienRepository.InsertNhanVien(nv);
                    TempData["Message"] = "Tạo mới thành công";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới nhân viên không thành công");
                }
            }

            catch
            {

            }
            return View();
        }

        // GET: NhanVienController1/Edit/5
        public ActionResult Edit(int id)
        {
            var nv = nhanVienRepository.GetNhanVienByID(id);
            return View(nv);
        }

        // POST: NhanVienController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NhanVien nv)
        {
            try
            {
                nhanVienRepository.UpdateNhanVien(nv);
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVienController1/Delete/5
        public ActionResult Delete(int id)
        {
            var nhanVienList = nhanVienRepository.GetNhanVienByID(id);
            return View(nhanVienList);
        }

        // POST: NhanVienController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NhanVien nv)
        {
            try
            {
                nhanVienRepository.DeleteNhanVien(id);
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> SelectedCatDelete)
        {
            nhanVienRepository.DeleteSelectedNhanVien(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} thàng thành công";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new NhanVienDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }   
}
