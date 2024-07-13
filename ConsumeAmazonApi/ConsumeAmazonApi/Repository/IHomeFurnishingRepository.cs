using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IHomeFurnishingRepository
    {
        Task<ResponseDto?> GetAllHomeFurnishAsync();
        Task<ResponseDto?> GetFurnishByIdAsync(int Id);
        Task<ResponseDto?> CreateHomeFrunishAsync(HomeFurnishingDto homeFurnishingDto);
        Task<ResponseDto?> DeleteHomeFurnsihAsync(int Id);
        Task<ResponseDto?> UpdateHomeFurnishAsync(HomeFurnishingDto homefurnishingDto);
    }
}
