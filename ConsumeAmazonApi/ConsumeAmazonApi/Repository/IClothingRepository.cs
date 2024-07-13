using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IClothingRepository
    {
        Task<ResponseDto?> GetAllClothesAsync();
        Task<ResponseDto?> GetClothesByIdAsync(int id);
        Task<ResponseDto?> UpdateClothesAsync(ClothingDto clothingdto);
        Task<ResponseDto?> DeleteClothesByIdAsync(int id);
        Task<ResponseDto?> CreateClothesAsync(ClothingDto clothingDto);
    }
}
