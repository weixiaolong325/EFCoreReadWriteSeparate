using Microsoft.EntityFrameworkCore;
using ReadWriteSeparate.DBModel;
using ReadWriteSeparate.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<DBConnectionOption>(builder.Configuration.GetSection("ConnectionStrings"));//注入多个链接
builder.Services.AddTransient<DbContext, MyDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
