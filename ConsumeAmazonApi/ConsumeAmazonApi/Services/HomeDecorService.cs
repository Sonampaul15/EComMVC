using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class HomeDecorService : IHomeDecoreRepository
    {
        private readonly IBaseRepository baseRepository;
        public HomeDecorService(IBaseRepository _baseRepository) 
        { 
          baseRepository = _baseRepository;
        }
        public async Task<ResponseDto?> CreateHomeDecoreAsync(HomeDecorDto homeDecoreDto)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType= ApiType.POST,
                Data = homeDecoreDto,
                Url = CrudAPIUrl+ "/api/Amazon/HomeDecore"
            });
        }

        public Task<ResponseDto?> DeleteHomeDecorAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllHomeDecorAsync()
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/HomeDecore"
            });
        }

        public Task<ResponseDto?> GetDecorByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateHomeDecorAsync(HomeDecorDto homedecoredto)
        {
            throw new NotImplementedException();
        }
    }
}
