using Microsoft.AspNetCore.Mvc;

namespace IdentityChatMail.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
