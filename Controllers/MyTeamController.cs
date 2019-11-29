using Microsoft.AspNetCore.Mvc;

namespace MyTeam.Controllers
{
    public class MyTeamController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}