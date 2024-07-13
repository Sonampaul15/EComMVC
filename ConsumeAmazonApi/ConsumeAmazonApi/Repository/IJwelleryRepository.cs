using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IJwelleryRepository
    {
        Task<ResponseDto?> GetJwelleryAsync();
        Task<ResponseDto?> GetJwelleryByIdAsync (string id);
        Task<ResponseDto?> DeleteJwelleryAsync (string id);
        Task<ResponseDto?> CreateJwelleryAsync(JwelleryDto jwelleryDto);
        Task<ResponseDto?> UpdateJwelleryAsync(JwelleryDto jwellerydto);
    }
}
