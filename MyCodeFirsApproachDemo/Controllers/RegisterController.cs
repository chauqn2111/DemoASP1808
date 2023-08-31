using Microsoft.AspNetCore.Mvc;
using MyCodeFirsApproachDemo.Models;

namespace MyCodeFirsApproachDemo.Controllers
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
                // Lưu dữ liệu vào cơ sở dữ liệu hoặc thực hiện các xử lý khác
                return RedirectToAction("Success");
            }
            else
            {
                // Trả về view đăng ký với các thông báo lỗi
                return View(model);
            }

        }
    }
}
