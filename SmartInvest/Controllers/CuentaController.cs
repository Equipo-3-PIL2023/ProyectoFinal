using Microsoft.AspNetCore.Mvc;

namespace SmartInvest.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
