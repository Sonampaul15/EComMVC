using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class GroceryController : Controller
    {
        private readonly IGroceryRepository GroceryRepo;
        public GroceryController(IGroceryRepository _GroceryRepo) 
        {
            
            GroceryRepo = _GroceryRepo;
        }
        public async Task<IActionResult> GetList()
        {
            List<GroceryDto> Dto = new List<GroceryDto>();
            ResponseDto response = await GroceryRepo.GetAllGroceryAsync();
            if (response != null && response.IsSuccess)
            {
                Dto = JsonConvert.DeserializeObject<List<GroceryDto>>(Convert.ToString(response.Result));
            }
            return View(Dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(GroceryDto grocery)
        {
            ResponseDto response = await GroceryRepo.CreateGroceryAsync(grocery);
            if(response != null && response.IsSuccess)
            {
                return RedirectToAction ("Index","Home");
            }
            return View();
        }
    }
}
