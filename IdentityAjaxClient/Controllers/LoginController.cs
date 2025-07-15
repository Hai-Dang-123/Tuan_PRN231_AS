using Microsoft.AspNetCore.Mvc;

namespace IdentityAjaxClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
