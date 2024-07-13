using ConsumeAmazonApi.DTO;

namespace ConsumeAmazonApi.Repository
{
    public interface IAuthRepository
    {
        Task<ResponseDto?> RegisterAsync(RegiRequestDto request);
        Task<ResponseDto?> AssignRoleAsync(RegiRequestDto requestDto);

        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequest);
    }
}
