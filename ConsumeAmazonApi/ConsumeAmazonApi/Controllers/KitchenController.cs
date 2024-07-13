using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class KitchenController : Controller
    {
        private readonly IKitchenRepository KitchRepo;
        public KitchenController(IKitchenRepository _KitchRepo)
        {
            KitchRepo = _KitchRepo;
        }
        public async Task<IActionResult> GetList()
        {
            List<KitchenDto> dto= new List<KitchenDto>();
            ResponseDto response = await KitchRepo.GetAllKitchenAsync();
            if (response != null&& response.IsSuccess)
            {
                dto= JsonConvert.DeserializeObject<List<KitchenDto>>(Convert.ToString(response.Result));
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(KitchenDto kitchen)
        {
            ResponseDto response = await KitchRepo.CreateKitchenAsync(kitchen);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index","Home");
            }
            return View(kitchen);
        }
    }
}
