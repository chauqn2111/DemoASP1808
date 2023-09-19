using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCodeFirsApproachDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,User")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(Request.Query["ReturnUrl"]))
            {
                return Redirect("" + Request.Query["ReturnUrl"]);
            }
            return View();
        }
    }
}
