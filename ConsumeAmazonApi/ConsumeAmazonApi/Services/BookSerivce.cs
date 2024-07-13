using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class BookSerivce : IBooksRepository
    {
        private readonly IBaseRepository baseRepository;
        public BookSerivce(IBaseRepository _baseRepository) 
        {
         baseRepository = _baseRepository;
        }
        public async Task<ResponseDto?> CreateBooksByNameAsync(BooksDto bookDto)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = bookDto,
                Url = CrudAPIUrl + "/api/Amazon/Books"
            });
        }

        public Task<ResponseDto?> DeleteBooksByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllBooksAsync()
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/Books"
            });
        }

        public Task<ResponseDto?> GetBooksByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateBooksAsync(BooksDto bookdto)
        {
            throw new NotImplementedException();
        }
    }
}
