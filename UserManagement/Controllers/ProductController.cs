using Microsoft.AspNetCore.Mvc;

namespace UserManagement.web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
