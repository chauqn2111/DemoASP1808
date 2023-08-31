using Microsoft.AspNetCore.Mvc;
using MyCodeFirtsApproach.Models;

namespace MyCodeFirtsApproach.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return View(model);
            }
        }
    }
}
