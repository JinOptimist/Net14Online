using Microsoft.AspNetCore.Builder;
using Net14Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net14Web.DbStuff;
using Net14Web.Services.RealEstate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Net14Web; Integrated Security=True";
builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));
//builder.Services.AddScoped<WebDbContext>();

var ConnectionStringRealEsate = "Server=localhost; Database=Net14WebRE; Integrated Security=True";
builder.Services.AddDbContext<WebDbContextRealEstate>(x => x.UseSqlServer(ConnectionStringRealEsate));



builder.Services.AddScoped<HeroBuilder>(diContainer =>
{
    var randomHelper = diContainer.GetService<RandomHelper>();
    return new HeroBuilder(randomHelper);
});

// builder.Services.AddTransient<RandomHelper>();
builder.Services.AddScoped<RandomHelper>();
// builder.Services.AddSingleton<RandomHelper>();

builder.Services.AddScoped<DeleteUser>();
builder.Services.AddScoped<IdBuilder>();
builder.Services.AddScoped<UpdateUser>();
builder.Services.AddScoped<UserBuilder>();
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
