using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IElectronicsRepository
    {
        Task<ResponseDto?> GetElectronicsAsync();
        Task<ResponseDto?> GetElectronicsByIdAsync(int id);

        Task<ResponseDto?> DeleteElectronicsAsync(int id);

        Task<ResponseDto?> UpdateElectronicsAsync(ElectronicsDto electronicsDto);

        Task<ResponseDto?> CreateElectronicsAsync(ElectronicsDto ElectDto);
    }
}
