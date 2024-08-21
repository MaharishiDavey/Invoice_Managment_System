using Microsoft.AspNetCore.Mvc;

namespace InvoiceWeb.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
