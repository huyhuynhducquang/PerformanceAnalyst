using Microsoft.EntityFrameworkCore;
using PerformanceAnalyst.Repositories;
using PerformanceAnalyst.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddDbContext<PerformanceDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("PerformanceConnectionString")));

services.AddTransient<IMovieRepository, MovieRepository>();
services.AddTransient<IPriceFetcherService, PriceFetcherService>();
services.AddTransient<IProductService, ProductService>();

services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
