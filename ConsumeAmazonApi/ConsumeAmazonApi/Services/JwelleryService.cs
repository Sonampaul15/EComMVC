using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class JwelleryService : IJwelleryRepository
    {
        private readonly IBaseRepository repository;
        public JwelleryService(IBaseRepository _repository)
        {
            repository = _repository;
        }
        public async Task<ResponseDto?> CreateJwelleryAsync(JwelleryDto jwelleryDto)
        {
            return await repository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = jwelleryDto,
                Url= CrudAPIUrl + "/api/Amazon/Jwellery"
            });
        }

        public Task<ResponseDto?> DeleteJwelleryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetJwelleryAsync()
        {
            return await repository.SendAsync(new RequestDto()
            {
                apiType= ApiType.GET,
                Data="",
                Url = CrudAPIUrl + "/api/Amazon/Jwellery"
            });
        }

        public Task<ResponseDto?> GetJwelleryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateJwelleryAsync(JwelleryDto jwellerydto)
        {
            throw new NotImplementedException();
        }
    }
}
