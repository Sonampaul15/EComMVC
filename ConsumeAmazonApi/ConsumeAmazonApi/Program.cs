using ConsumeAmazonApi.Repository;
using ConsumeAmazonApi.Services;
using ConsumeAmazonApi.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IBaseRepository, BaseService>();
builder.Services.AddScoped<IBaseRepository,BaseService>();
builder.Services.AddHttpClient<IHomeFurnishingRepository, HomeFurnishingService>();
builder.Services.AddScoped<IHomeFurnishingRepository, HomeFurnishingService>();
builder.Services.AddHttpClient<IJwelleryRepository, JwelleryService>();
builder.Services.AddScoped<IJwelleryRepository, JwelleryService>();
builder.Services.AddHttpClient<IKitchenRepository, KitchenService>();
builder.Services.AddScoped<IKitchenRepository, KitchenService>();
builder.Services.AddHttpClient<IElectronicsRepository, ElectronicService>();
builder.Services.AddScoped<IElectronicsRepository, ElectronicService>();
builder.Services.AddHttpClient<IHomeDecoreRepository, HomeDecorService>();
builder.Services.AddScoped<IHomeDecoreRepository, HomeDecorService>();
builder.Services.AddHttpClient<ICosmeticsRepository, CosmeticService>();
builder.Services.AddScoped<ICosmeticsRepository, CosmeticService>();
builder.Services.AddHttpClient<IClothingRepository, ClothingService>();
builder.Services.AddScoped<IClothingRepository, ClothingService>();
builder.Services.AddHttpClient<IBooksRepository,BookSerivce>();
builder.Services.AddScoped<IBooksRepository, BookSerivce>();
builder.Services.AddHttpClient<IGroceryRepository,GroceryService>();
builder.Services.AddScoped<IGroceryRepository, GroceryService>();
builder.Services.AddScoped<IAuthRepository, AuthService>();
builder.Services.AddScoped<ITokenProvider,TokenProviderService>();
StaticData.CrudAPIUrl = builder.Configuration["ServiceUrl:CrudApi"];
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Login";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
