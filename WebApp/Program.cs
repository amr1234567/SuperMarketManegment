using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Plugin.InMemory;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataSourcePluginsInterfaces;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// DI
builder.Services.AddScoped<ICategoryRepositry,CategoryInMemoryRepositry>();

builder.Services.AddScoped<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddScoped<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
