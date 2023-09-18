using AutomobileLibrary.DataAccess;
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
    public class HoaDonController : Controller
    {
        IHoaDonRepository hoaDonRepository = null;
        public HoaDonController() => hoaDonRepository =new HoaDonRepository();
        [HttpGet]
        // GET: HoaDonController
        public ActionResult Index(string searchString, int? page, string sortBy)
        {

            var hoaDonList = hoaDonRepository.GetHoaDons(sortBy).ToPagedList(page ?? 1, 5);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                hoaDonList = hoaDonRepository.GetHoaDonByName(searchString, sortBy).ToPagedList(page ?? 1, 5);
            }
            //TempData["searchString"] = searchString;
            return View(hoaDonList);
        }

        // GET: HoaDonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HoaDonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoaDonController/Create
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

        // GET: HoaDonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoaDonController/Edit/5
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

        // GET: HoaDonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HoaDonController/Delete/5
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
