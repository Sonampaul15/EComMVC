using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class HomeFurnishingService : IHomeFurnishingRepository
    {
        private readonly IBaseRepository Base;
        public HomeFurnishingService(IBaseRepository _Base)
        {
            Base = _Base;
        }
        public async Task<ResponseDto?> CreateHomeFrunishAsync(HomeFurnishingDto homeFurnishingDto)
        {
            return await Base.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = homeFurnishingDto,
                Url = CrudAPIUrl + "/Api/Amazon/homeFurnishing"
            });
        }

        public Task<ResponseDto?> DeleteHomeFurnsihAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllHomeFurnishAsync()
        {
            return await Base.SendAsync(new RequestDto()
            {
                apiType = ApiType.GET,
                Data = "",
                Url= CrudAPIUrl +"/Api/Amazon/homeFurnishing"
            });
        }

        public Task<ResponseDto?> GetFurnishByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateHomeFurnishAsync(HomeFurnishingDto homefurnishingDto)
        {
            throw new NotImplementedException();
        }
    }
}
