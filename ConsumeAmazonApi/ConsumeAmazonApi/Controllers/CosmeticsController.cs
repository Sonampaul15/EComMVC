using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class CosmeticsController : Controller
    {
        private readonly ICosmeticsRepository CosRepo;
        public CosmeticsController(ICosmeticsRepository cosRepo)
        {
            CosRepo = cosRepo;
        }
        public async Task<IActionResult> GetList()
        {
            List<CosmeticsDto> dto = new();
            ResponseDto response = await CosRepo.GetAllCosmeticsAsync();
            if (response != null && response.IsSuccess)
            {
                dto = JsonConvert.DeserializeObject<List<CosmeticsDto>>(Convert.ToString(response.Result));
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateList(CosmeticsDto CosDto)
        {
            ResponseDto response = await CosRepo.CreateCosmeticsAsync(CosDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index","Home");
            }
            return View(CosDto);
        }
    }
}
