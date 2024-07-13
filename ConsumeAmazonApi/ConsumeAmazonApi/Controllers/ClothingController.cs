using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class ClothingController : Controller
    {
        private readonly IClothingRepository ClothRepo;
        public ClothingController(IClothingRepository _ClothRepo)
        {
            ClothRepo = _ClothRepo;
        }
        public async Task<IActionResult> GetList()
        {
            List<ClothingDto> Dto = new List<ClothingDto>();
            ResponseDto response = await ClothRepo.GetAllClothesAsync();
            if (response != null && response.IsSuccess)
            {
                Dto = JsonConvert.DeserializeObject<List<ClothingDto>>(Convert.ToString(response.Result));
            }
            return View(Dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateList(ClothingDto clothingDto)
        {
            ResponseDto response = await ClothRepo.CreateClothesAsync(clothingDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction ("Index","Home");
            }
            return View(clothingDto);
        }
    }
}
