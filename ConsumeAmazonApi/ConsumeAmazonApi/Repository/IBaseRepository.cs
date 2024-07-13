using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IBaseRepository
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
