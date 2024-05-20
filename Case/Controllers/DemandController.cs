using Case.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Case.Controllers
{
    public class DemandController : Controller
    {
        private readonly IDemandService _demandService;

        public DemandController(IDemandService demandService)
        {
            _demandService = demandService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDemandOption() => Json(await _demandService.GetDemandOption());
    }
}
