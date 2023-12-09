using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Plugin.InMemory;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.ProductsUseCases;
using UseCases.UseCasesInterfaces;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Plugin.DataBase.Sql;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketDb"));
});

builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AccoutContextConnection"));
});
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountContext>();

// DI
//builder.Services.AddScoped<ICategoryRepositry,CategoryInMemoryRepositry>();
//builder.Services.AddScoped<IProductRepositry, ProductInMemoryRepositry>();
//builder.Services.AddScoped<ITransactionsRepositry, TransactionsInMemoryRepositry>();

builder.Services.AddScoped<ICategoryRepositry, CategoryRepositry>();
builder.Services.AddScoped<IProductRepositry, ProductRepositry>();
builder.Services.AddScoped<ITransactionsRepositry, TransactionsRepositry>();


builder.Services.AddScoped<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddScoped<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();

builder.Services.AddScoped<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddScoped<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddScoped<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
builder.Services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddScoped<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddScoped<IGetProductsByCategoryIdUseCase, GetProductsByCategoryIdUseCase>();

builder.Services.AddScoped<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddScoped<IGetTodayTransactiosUseCase, GetTodayTransactiosUseCase>();
builder.Services.AddScoped<ISearchTransactionsUseCase, SearchTransactionsUseCase>();


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
