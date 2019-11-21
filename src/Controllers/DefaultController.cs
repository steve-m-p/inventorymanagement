using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controller
{
    public class DefaultController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}