using Microsoft.AspNetCore.Authentication.Cookies;
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

// Configuração da autenticação com cookies
builder.Services.AddAuthentication("CookieAuthentication")
	.AddCookie("CookieAuthentication", options =>
	{
		options.LoginPath = "/Login"; // Caminho para a página de login
		options.LogoutPath = "/Logout"; // Caminho para a página de logout
		options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Duração do cookie
		options.SlidingExpiration = true; // Atualiza o cookie se o usuário estiver ativo
	});

// Configuração de cultura (se necessário)
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new List<CultureInfo> {
//        new CultureInfo("pt-BR")
//    };
//
//    options.DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilita a autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

builder.Services.AddMemoryCache();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
