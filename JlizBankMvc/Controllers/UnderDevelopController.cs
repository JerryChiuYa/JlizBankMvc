using Microsoft.AspNetCore.Mvc;

namespace JlizBankMvc.Controllers
{
    public class UnderDevelopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
