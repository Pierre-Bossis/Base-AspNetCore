using entrainementAspNetCore.Data.Interface;
using entrainementAspNetCore.Data.Service;
using entrainementAspNetCore.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("api", config =>
{
    config.BaseAddress = new Uri("https://localhost:7197/");
}).AddHttpMessageHandler<TokenHandler>();

builder.Services.AddScoped<IArticleRepository,ArticleService>();
builder.Services.AddScoped<IUserRepository,UserService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<TokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
