using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class KitchenService : IKitchenRepository
    {
        private readonly IBaseRepository repository;

        public KitchenService(IBaseRepository _repository) 
        {
            repository = _repository;
        }
        public async Task<ResponseDto?> CreateKitchenAsync(KitchenDto kitchenDto)
        {
            return await repository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = kitchenDto,
                Url = CrudAPIUrl + "/api/Amazon/Kitchen"
            });
        }

        public Task<ResponseDto?> DeleteKitchenAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllKitchenAsync()
        {
            return await repository.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/Kitchen"
            });
        }

        public Task<ResponseDto?> GetKitchenbyIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateKitchenAsync(KitchenDto kitchendto)
        {
            throw new NotImplementedException();
        }
    }
}
