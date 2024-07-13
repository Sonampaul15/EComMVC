using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.Services
{
    public class BaseService : IBaseRepository
    {
        private readonly IHttpClientFactory Factory;

        public BaseService(IHttpClientFactory _Factory)
        {
            Factory = _Factory;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = Factory.CreateClient("CrudApiClient");
                HttpRequestMessage message = new HttpRequestMessage();
                message.RequestUri = new Uri(requestDto.Url);
                if(requestDto.Data!=null)
                {
                    message.Content= new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                switch(requestDto.apiType)
                {
                    case ApiType.POST : message.Method=HttpMethod.Post; break;
                    case ApiType.PUT: message.Method=HttpMethod.Put; break;
                    case ApiType.DELETE : message.Method=HttpMethod.Delete; break;
                    default: message.Method=HttpMethod.Get; break;
                }

                HttpResponseMessage apiResponse = null;
                apiResponse= await client.SendAsync(message);

                switch(apiResponse.StatusCode)
                {
                    case HttpStatusCode.Unauthorized: return new ResponseDto() { IsSuccess = false, Message = "UnAuthorized" }; break;
                    case HttpStatusCode.Forbidden: return new ResponseDto() { IsSuccess = false, Message = "AccessDenied" }; break;
                    case HttpStatusCode.NotFound: return new ResponseDto() { IsSuccess = false, Message = "Not Found" };break;
                    case HttpStatusCode.InternalServerError: return new ResponseDto() { IsSuccess = false, Message = "InternalServerError" };break;

                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };
                return dto;
                
            }
        }
    }
}
