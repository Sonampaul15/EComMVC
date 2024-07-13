using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IGroceryRepository
    {
        Task<ResponseDto?> GetAllGroceryAsync();
        Task<ResponseDto?> GetGroceryAsyncById(string id);

        Task<ResponseDto?> CreateGroceryAsync(GroceryDto groceryDto);

        Task<ResponseDto?> UpdateGroceryAsync(GroceryDto grocerydto);

        Task<ResponseDto?> DeleteGroceryAsync(string id);
    }
}
