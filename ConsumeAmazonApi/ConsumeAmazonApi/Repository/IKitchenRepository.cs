using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IKitchenRepository
    {
        Task<ResponseDto?> GetAllKitchenAsync();
        Task<ResponseDto?> GetKitchenbyIdAsync(int Id);
        Task<ResponseDto?> DeleteKitchenAsync(int Id);
        Task<ResponseDto?> CreateKitchenAsync(KitchenDto kitchenDto);
        Task<ResponseDto?> UpdateKitchenAsync(KitchenDto kitchendto);
    }
}
