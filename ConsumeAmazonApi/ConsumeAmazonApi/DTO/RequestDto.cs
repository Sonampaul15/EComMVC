using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using static ConsumeAmazonApi.Utility.StaticData;

namespace ConsumeAmazonApi.DTO
{
    public class RequestDto
    {
        public ApiType apiType { get; set; }= ApiType.GET;
        public string Url { get; set; }
        public Object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
