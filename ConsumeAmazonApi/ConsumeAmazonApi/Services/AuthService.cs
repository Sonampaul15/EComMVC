using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IBaseRepository baseRepository;
        public AuthService(IBaseRepository _baseRepository) 
        {
          baseRepository = _baseRepository;
        }

        public async Task<ResponseDto?> AssignRoleAsync(RegiRequestDto requestDto)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = requestDto,
                Url = CrudAPIUrl + "/api/Authentication/AssignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequest)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = loginRequest,
                Url = CrudAPIUrl + "/api/Authentication/Login"
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegiRequestDto request)
        {
            return await baseRepository.SendAsync(new RequestDto()
            {
                apiType = ApiType.POST,
                Data = request,
                Url = CrudAPIUrl + "/api/Authentication/Registration"
            });
        }
    }
}
