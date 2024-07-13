using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class HomeDecorController : Controller
    {
        private readonly IHomeDecoreRepository decoreRepository;
        public HomeDecorController(IHomeDecoreRepository _decoreRepository)
        {
            decoreRepository = _decoreRepository;
        }
        public async Task<IActionResult> GetList()
        {
            List<HomeDecorDto> Decor = new List<HomeDecorDto>();
            ResponseDto response = await decoreRepository.GetAllHomeDecorAsync();
            if (response != null&& response.IsSuccess)
            {
                Decor = JsonConvert.DeserializeObject<List<HomeDecorDto>>(Convert.ToString(response.Result));
            }
            return View(Decor);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(HomeDecorDto decor)
        {
            ResponseDto response = await decoreRepository.CreateHomeDecoreAsync(decor);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(decor);
        }
    }
}
