using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.Services;
using Net14Web.Services.DndServices;
using Net14Web.Services.GameShop;
using Net14Web.Services.Movies;
using Net14Web.Services.RealEstate;
using Net14Web.Services.Sattelite;
using Net14Web.DbStuff.SeedData;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Net14WebDb");
var connStringManagmentCompany = builder.Configuration.GetConnectionString("ManagmentCompany");

builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddDbContext<ManagmentCompanyDbContext>(x => x.UseSqlServer(connStringManagmentCompany));

//builder.Services.AddScoped<WebDbContext>();

//using var scope = app.Services.CreateScope();
//var db = scope.ServiceProvider.GetService<WebDbContext>();
//await db.Database.MigrateAsync();
//await LifeScoreSeedData.AddDefaultTeams(db);
//await LifeScoreSeedData.AddDefaultSportGames(db);

builder.Services.AddScoped<HeroBuilder>(diContainer =>
{
    var randomHelper = diContainer.GetService<RandomHelper>();
    return new HeroBuilder(randomHelper);
});

// builder.Services.AddTransient<RandomHelper>();
builder.Services.AddScoped<RandomHelper>();
// builder.Services.AddSingleton<RandomHelper>();

builder.Services.AddScoped<IGameShopRepository, GameShopRepository>();
builder.Services.AddScoped<CommentBuilder>();
builder.Services.AddScoped<ErrorBuilder>();
builder.Services.AddScoped<MovieBuilder>();
builder.Services.AddScoped<Net14Web.Services.Movies.UserBuilder>();
builder.Services.AddScoped<UserEditHelper>();
builder.Services.AddScoped<MovieEditHelper>();
builder.Services.AddScoped<LoginHelper>();
builder.Services.AddScoped<ObjectBuilder>();

builder.Services.AddScoped<DeleteUser>();
builder.Services.AddScoped<IdBuilder>();
builder.Services.AddScoped<UpdateUser>();
builder.Services.AddScoped<Net14Web.Services.RealEstate.UserBuilder>();
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
