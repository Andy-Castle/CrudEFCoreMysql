using CrudEFCoreMysql.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Cadena de conexion a la base de datos Mysql
var connectionString = "server=ANDY; port=3306; database=EFCoreMysql; user=root; password=root; Persist Security Info=False; Connect Timeout=300";

var serverVersion = new MySqlServerVersion(new Version(9, 1, 0));

//Configuración a la conexion de MySql
builder.Services.AddDbContext<ApplicationDbContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)
    //Solo para etapa de desarrollo, no producción
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    );

// Add services to the container.
builder.Services.AddControllersWithViews();

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
