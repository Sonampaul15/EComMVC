using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IHomeDecoreRepository
    {
        Task<ResponseDto?> GetAllHomeDecorAsync();
        Task<ResponseDto?> GetDecorByIdAsync(int Id);
        Task<ResponseDto?> CreateHomeDecoreAsync(HomeDecorDto homeDecoreDto);
        Task<ResponseDto?> DeleteHomeDecorAsync(int Id);
        Task<ResponseDto?> UpdateHomeDecorAsync(HomeDecorDto homedecoredto);
    }
}
