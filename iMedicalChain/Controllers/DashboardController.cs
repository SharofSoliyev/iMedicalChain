using Microsoft.AspNetCore.Mvc;

namespace iMedicalChain.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
