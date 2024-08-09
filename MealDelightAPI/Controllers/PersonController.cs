using Microsoft.AspNetCore.Mvc;

namespace MealDelightAPI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
