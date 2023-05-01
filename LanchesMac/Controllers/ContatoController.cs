using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
