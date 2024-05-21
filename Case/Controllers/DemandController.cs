using Case.Dtos;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Demand name'leri list olarak döndürür
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDemandOption() => Json(await _demandService.GetDemandOption());

        /// <summary>
        /// Demand kayıt eder
        /// </summary>
        /// <param name="demandCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateDemand(DemandCreateDto demandCreateDto)
        {
            await _demandService.CreateAsyncDemand(demandCreateDto);
            return Json("Kayıt Başarılı");
        }

        /// <summary>
        /// Demands page index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Demands()
        {
            return View();
        }

        /// <summary>
        /// Pagging yaparak table için veri döndür
        /// </summary>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetDemands(int start, int length, int draw) => Json(await _demandService.GetAllDemands(start, length, draw));
    }
}
