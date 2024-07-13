using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Models;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class HomeFurnishingController : Controller
    {
        private readonly IHomeFurnishingRepository HomeRepo;

        public HomeFurnishingController(IHomeFurnishingRepository _HomeRepo)
        {
            HomeRepo = _HomeRepo;
        }
        public async Task<IActionResult> GetList()
        {
            List<HomeFurnishingDto> Dto = new List<HomeFurnishingDto>();
            ResponseDto response = await HomeRepo.GetAllHomeFurnishAsync();
            if (response != null&& response.IsSuccess)
            {
                Dto = JsonConvert.DeserializeObject<List<HomeFurnishingDto>>(Convert.ToString(response.Result));
            }
            return View(Dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateList(HomeFurnishingDto furnishingDto)
        {
            ResponseDto response = await HomeRepo.CreateHomeFrunishAsync(furnishingDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(furnishingDto);
        }
    }
}
