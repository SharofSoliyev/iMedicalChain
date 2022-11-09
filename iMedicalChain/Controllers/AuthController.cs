using Microsoft.AspNetCore.Mvc;

namespace iMedicalChain.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
