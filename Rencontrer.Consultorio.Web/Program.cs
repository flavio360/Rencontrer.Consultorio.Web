using Microsoft.AspNetCore.Localization;
using Rencontrer.Consultorio.Web.Data.Interface;
using Rencontrer.Consultorio.Web.Data.Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var HttpClientRencontrerAPIServer = Environment.GetEnvironmentVariable("RencontrerAPI") ?? builder.Configuration["ServiceUrls:RencontrerAPI"];

#region HttpClient MS
builder.Services.AddHttpClient<ILoginService, LoginService>(c => c.BaseAddress = new Uri(HttpClientRencontrerAPIServer));

#endregion
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var app = builder.Build();



#region CultureInfo
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{

//    var supportedCultures = new List<CultureInfo> {
//                    new CultureInfo("pt-BR")
//                };

//    options.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;


//});
#endregion







// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseAuthentication(); // Habilita a autenticação
app.UseAuthorization();  // Habilita a autorização
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

builder.Services.AddMemoryCache();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Index}/{id?}");


app.Run();
