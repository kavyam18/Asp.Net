using Microsoft.AspNetCore.Mvc;

namespace ProductStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
