using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class ElectronicService : IElectronicsRepository
    {
        private readonly IBaseRepository repository;

        public ElectronicService(IBaseRepository _repository) 
        {
          repository = _repository;
        }
        public async Task<ResponseDto?> CreateElectronicsAsync(ElectronicsDto ElectDto)
        {
            return await repository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = ElectDto,
                Url= CrudAPIUrl +"/api/Amazon/Electronics"
            });
        }

        public Task<ResponseDto?> DeleteElectronicsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetElectronicsAsync()
        {
            return await repository.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/Electronics"
            });
        }

        public Task<ResponseDto?> GetElectronicsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateElectronicsAsync(ElectronicsDto electronicsDto)
        {
            throw new NotImplementedException();
        }
    }
}
