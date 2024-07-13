using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class JwelleryController : Controller
    {
        private readonly IJwelleryRepository JwellRepo;

        public JwelleryController(IJwelleryRepository jwellRepo)
        {
            JwellRepo = jwellRepo;
        }
        public async Task<IActionResult> GetList()
        {
            List<JwelleryDto> dtos = new();
            ResponseDto? responseDto = await JwellRepo.GetJwelleryAsync();
            if (responseDto != null && responseDto.IsSuccess)
            {
                dtos = JsonConvert.DeserializeObject<List<JwelleryDto>>(Convert.ToString(responseDto.Result));
            }
            return View(dtos);
        }
        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList(JwelleryDto jwelleryDto)
        {
            ResponseDto response = await JwellRepo.CreateJwelleryAsync(jwelleryDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index","Home");
            }
            return View(jwelleryDto);
        }

    }
}
