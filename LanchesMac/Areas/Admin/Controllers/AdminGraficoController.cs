using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LanchesMac.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendasService;

        public AdminGraficoController(GraficoVendasService graficoVendasService)
        {
            _graficoVendasService = graficoVendasService ?? throw new ArgumentNullException(nameof(graficoVendasService));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesBendasTotais = _graficoVendasService.GetVendasLanches(dias);
             
            return Json(lanchesBendasTotais);
        }

        [HttpGet]
        public IActionResult Index(int dias)
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal(int dias)
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }
    }
}
