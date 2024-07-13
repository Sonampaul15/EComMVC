using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class ElectronicsController : Controller
    {
        private readonly IElectronicsRepository ElecRepo;
        public ElectronicsController(IElectronicsRepository elecRepo) 
        { 
            ElecRepo = elecRepo;
        
        }
        public async Task<IActionResult> GetList()
        {
            List<ElectronicsDto> Dto = new();
            ResponseDto response = await ElecRepo.GetElectronicsAsync();
            if (response != null && response.IsSuccess)
            {
                Dto = JsonConvert.DeserializeObject<List<ElectronicsDto>>(Convert.ToString(response.Result));
            }
            return View(Dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(ElectronicsDto electronicsDto)
        {
            ResponseDto response = await ElecRepo.CreateElectronicsAsync(electronicsDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
