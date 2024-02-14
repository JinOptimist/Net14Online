using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionStringRealEsate = builder.Configuration.GetConnectionString("Net14WebRE");
builder.Services.AddDbContext<WebRealEstateDbContext>(x => x.UseSqlServer(connectionStringRealEsate));

// Repositories
builder.Services.AddScoped<ApartmentOwnerRepository>();

// Services
builder.Services.AddScoped<DeleteUser>();
builder.Services.AddScoped<UpdateUser>();

builder.Services.AddHttpContextAccessor();

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

app.UseAuthentication(); // Who I am?
app.UseAuthorization(); // May I?


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();