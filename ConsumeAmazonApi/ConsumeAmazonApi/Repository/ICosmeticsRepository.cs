using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface ICosmeticsRepository
    {
        Task<ResponseDto?> CreateCosmeticsAsync(CosmeticsDto cosmeticsDto);
        Task<ResponseDto?> UpdateCosmeticsAsync(CosmeticsDto cosmeticsdto);
        Task<ResponseDto?> DeleteCosmeticsAsync(int Id);
        Task<ResponseDto?> GetCosmeticsByIdAsync(int id);
        Task<ResponseDto?> GetAllCosmeticsAsync();
    }
}
