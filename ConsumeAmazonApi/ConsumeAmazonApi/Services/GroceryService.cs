using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class GroceryService : IGroceryRepository
    {
        private readonly IBaseRepository baseRepository;
        public GroceryService(IBaseRepository _baseRepository) 
        {
            baseRepository = _baseRepository;
                
        }

        public async Task<ResponseDto?> CreateGroceryAsync(GroceryDto groceryDto)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = groceryDto,
                Url = CrudAPIUrl + "/api/Amazon/Grocery"
            });
        }

        public Task<ResponseDto?> DeleteGroceryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllGroceryAsync()
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/Grocery"
            });
        }

        public Task<ResponseDto?> GetGroceryAsyncById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateGroceryAsync(GroceryDto grocerydto)
        {
            throw new NotImplementedException();
        }
    }
}
