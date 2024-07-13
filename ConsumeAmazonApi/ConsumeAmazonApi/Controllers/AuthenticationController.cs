using ConsumeAmazonApi.DTO;
using ConsumeAmazonApi.Repository;
using ConsumeAmazonApi.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ConsumeAmazonApi.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAuthRepository authRepository;
        private readonly ITokenProvider tokenProvider;
        public AuthenticationController(IAuthRepository _authRepository, ITokenProvider _tokenProvider) 
        {
         authRepository = _authRepository;
          tokenProvider = _tokenProvider;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterUser()
        {
            var roleList = new List<SelectListItem>()
            { new SelectListItem{Text=StaticData.RoleAdmin,Value=StaticData.RoleAdmin},
              new SelectListItem{Text=StaticData.RoleAccount,Value=StaticData.RoleAccount},
              new SelectListItem{Text=StaticData.RoleCustomer,Value=StaticData.RoleCustomer},
              new SelectListItem{Text=StaticData.RoleTransport,Value=StaticData.RoleTransport},
            };
            ViewBag.RoleList = roleList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegiseterUser (RegiRequestDto regiRequest)
        {
            ResponseDto responseDto = await authRepository.RegisterAsync(regiRequest);
            ResponseDto responseRoleApi;
            if (responseDto != null && responseDto.IsSuccess)
            {
                if(string.IsNullOrEmpty(regiRequest.Role))
                {
                    regiRequest.Role= StaticData.RoleCustomer;
                }
                responseRoleApi=await authRepository.AssignRoleAsync(regiRequest);
                if (responseRoleApi != null && responseRoleApi.IsSuccess)
                {
                    TempData["success"] = "User Have Succesfully Registered";
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                TempData["error"] = "Error in registration";
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem {Text=StaticData.RoleCustomer, Value=StaticData.RoleCustomer},
                new SelectListItem {Text=StaticData.RoleAdmin, Value=StaticData.RoleAdmin},
                new SelectListItem {Text=StaticData.RoleTransport, Value=StaticData.RoleTransport},
                new SelectListItem {Text=StaticData.RoleOperator, Value=StaticData.RoleOperator},
                new SelectListItem {Text=StaticData.RoleAccount, Value=StaticData.RoleAccount},
            };
            ViewBag.RoleList = roleList;
            return View(regiRequest);
        }

        private async Task SingInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.Token);
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(x => x.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            ResponseDto response= await authRepository.LoginAsync(loginRequest);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDto loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));
                SingInUser(loginResponse);
                tokenProvider.SetToken(loginResponse.Token);
                TempData["success"] = "User Login Successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Error In Login";
                return View(loginRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult>Logout()
        {
            await HttpContext.SignOutAsync();
            tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }
    }
}
