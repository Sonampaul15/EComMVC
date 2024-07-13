using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class CosmeticService : ICosmeticsRepository
    {
        private readonly IBaseRepository baseRepository;
        public CosmeticService(IBaseRepository _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public async Task<ResponseDto?> CreateCosmeticsAsync(CosmeticsDto cosmeticsDto)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = cosmeticsDto,
                Url = CrudAPIUrl+"/api/Amazon/Cosmetics"
            });
        }

        public Task<ResponseDto?> DeleteCosmeticsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllCosmeticsAsync()
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/Cosmetics"
            });
        }

        public Task<ResponseDto?> GetCosmeticsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCosmeticsAsync(CosmeticsDto cosmeticsdto)
        {
            throw new NotImplementedException();
        }
    }
}
