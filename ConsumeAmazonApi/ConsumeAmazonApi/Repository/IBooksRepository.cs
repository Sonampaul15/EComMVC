using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IBooksRepository
    {
        Task<ResponseDto?> GetAllBooksAsync();
        Task<ResponseDto?> GetBooksByIdAsync(int id);
        Task<ResponseDto?> CreateBooksByNameAsync(BooksDto bookDto);

        Task<ResponseDto?> UpdateBooksAsync(BooksDto bookdto);
        Task<ResponseDto?> DeleteBooksByIdAsync(int id);
    }
}
