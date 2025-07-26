using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tasheel.PL.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        //[Authorize(Roles = "test")]   في حالة اضافةاي صلاحية صلاحية للمستخدم

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
