using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAmazonApi.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksRepository BookRepo;
        public BookController(IBooksRepository bookRepo) 
        {
           BookRepo = bookRepo;
        
        }
        public async Task<IActionResult> GetList()
        {
            List<BooksDto> Dto = new List<BooksDto>();
            ResponseDto responsedto = await BookRepo.GetAllBooksAsync();
            if (responsedto != null&& responsedto.IsSuccess)
            {
                Dto= JsonConvert.DeserializeObject<List<BooksDto>>(Convert.ToString(responsedto.Result));
            }
            return View(Dto);
        }

        [HttpGet]
        public async Task<IActionResult> CreateList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateList(BooksDto booksDto)
        {
            ResponseDto responseDto = await BookRepo.CreateBooksByNameAsync(booksDto);
            if (responseDto != null&& responseDto.IsSuccess)
            {
                return RedirectToAction("Index","Home");
            }
            return View(booksDto);
        }
    }
}
