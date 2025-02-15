using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShareItems_WebApp.Entities;
using ShareItems_WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddDataProtection();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
    

app.Run();
