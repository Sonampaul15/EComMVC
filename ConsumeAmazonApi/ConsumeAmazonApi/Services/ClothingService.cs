using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class ClothingService : IClothingRepository
    {
        private readonly IBaseRepository baseRepository;
        public ClothingService(IBaseRepository _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public async Task<ResponseDto?> CreateClothesAsync(ClothingDto clothingDto)
        {

            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = clothingDto,
                Url = CrudAPIUrl + "/api/Amazon/Clothes"
            });
        }

        public Task<ResponseDto?> DeleteClothesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> GetAllClothesAsync()
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = "",
                Url = CrudAPIUrl + "/api/Amazon/Clothes"
            });
        }

        public Task<ResponseDto?> GetClothesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateClothesAsync(ClothingDto clothingdto)
        {
            throw new NotImplementedException();
        }
    }
}
