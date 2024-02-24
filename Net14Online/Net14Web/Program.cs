using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Net14Web.Controllers;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.Booking;
using Net14Web.DbStuff.Repositories.GameShop;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.DbStuff.Repositories.PcShop;
using Net14Web.DbStuff.Repositories.TaskTracker;
using Net14Web.Services;
using Net14Web.Services.BondServices;
using Net14Web.Services.BookingPermissons;
using Net14Web.Services.DndServices;
using Net14Web.Services.GameShop;
using Net14Web.Services.Movies;
using Net14Web.Services.Movies.Permissions;
using Net14Web.Services.Sattelite;
using Net14Web.Services.TaskTrackerServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(AuthController.AUTH_KEY)
    .AddCookie(AuthController.AUTH_KEY, option =>
    {
        option.AccessDeniedPath = "/auth/deny";
        option.LoginPath = "/Auth/Login";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Net14WebDb");

builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));

//builder.Services.AddScoped<WebDbContext>();

builder.Services.AddScoped<HeroBuilder>(diContainer =>
{
    var randomHelper = diContainer.GetService<RandomHelper>();
    return new HeroBuilder(randomHelper);
});

// builder.Services.AddTransient<RandomHelper>();
builder.Services.AddScoped<RandomHelper>();
// builder.Services.AddSingleton<RandomHelper>();

// Repositories
builder.Services.AddScoped<GameShopRepository>();
builder.Services.AddScoped<HeroRepository>();
builder.Services.AddScoped<MoviesRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<WeaponRepository>();
builder.Services.AddScoped<HeroRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<PermissionRepository>();

builder.Services.AddScoped<GameCommentRepository>();
builder.Services.AddScoped<GameShopRepository>();
builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<DividendRepository>();
builder.Services.AddScoped<SearchRepository>();
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<UserRepositoryPcShop>();
builder.Services.AddScoped<PcsRepositoryPcShop>();
builder.Services.AddScoped<SatteliteController>();
builder.Services.AddScoped<BondsRepository>();
builder.Services.AddScoped<CouponsRepository>();

// Services
builder.Services.AddScoped<CommentBuilder>();
builder.Services.AddScoped<MovieBuilder>();
builder.Services.AddScoped<UserBuilder>();
builder.Services.AddScoped<UserEditHelper>();
builder.Services.AddScoped<MovieEditHelper>();
builder.Services.AddScoped<TaskPermissions>();
builder.Services.AddScoped<ObjectBuilder>();
builder.Services.AddScoped<RegistrationHelper>();
builder.Services.AddScoped<CreateFilePathHelper>();
builder.Services.AddScoped<UploadFileHelper>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<HeroPermissions>();
builder.Services.AddScoped<CommentPermissions>();
builder.Services.AddScoped<UserPermissions>();
builder.Services.AddScoped<MoviePermissions>();
builder.Services.AddScoped<AdminPanelPermissions>();
builder.Services.AddScoped<BookingPermission>();
builder.Services.AddScoped<BondPermissions>();
builder.Services.AddScoped<CouponPermissions>();


builder.Services.AddScoped<GamesService>();
builder.Services.AddScoped<GameCommentService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

SeedExtentoin.Seed(app);

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
