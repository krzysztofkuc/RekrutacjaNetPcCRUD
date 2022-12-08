
using Microsoft.EntityFrameworkCore;
using RekrutacjaNetPcCRUD.Interfaces;
using RekrutacjaNetPcCRUD.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["RekrutacjaNetPcDb"];
builder.Services.AddControllers();
builder.Services.AddTransient<IContactsRepository, ContactsRepository>();
builder.Services.AddDbContext<ContactsDbContext>(options =>options.UseSqlServer("connString"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
