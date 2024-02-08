using Microsoft.EntityFrameworkCore;
using Net14Web.Controllers;
using Net14Web.DbStuff;
using Net14Web.DbStuff.RealEstate;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.GameShop;
using Net14Web.DbStuff.Repositories.ManagmentCompany;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Services;
using Net14Web.Services.DndServices;
using Net14Web.Services.Movies;
using Net14Web.Services.RealEstate;
using Net14Web.Services.Sattelite;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(AuthController.AUTH_KEY_MC)
    .AddCookie(AuthController.AUTH_KEY_MC, option =>
    {
        option.LoginPath = "/Auth/McLogin";
    });

builder.Services
    .AddAuthentication(AuthController.AUTH_KEY)
    .AddCookie(AuthController.AUTH_KEY, option =>
    {
        option.LoginPath = "/Auth/Login";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Net14WebDb");
var connStringManagmentCompany = builder.Configuration.GetConnectionString("ManagmentCompany");

builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddDbContext<ManagmentCompanyDbContext>(x => x.UseSqlServer(connStringManagmentCompany));

var connectionStringRealEsate = builder.Configuration.GetConnectionString("Net14WebRE");
builder.Services.AddDbContext<WebRealEstateDbContext>(x => x.UseSqlServer(connectionStringRealEsate));
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
builder.Services.AddScoped<TaskStatusRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<McUserRepository>();
builder.Services.AddScoped<UserTaskRepository>();
builder.Services.AddScoped<MemberPermissionRepository>();
builder.Services.AddScoped<MemberStatusRepository>(); 
builder.Services.AddScoped<GameShopRepository>();
builder.Services.AddScoped<HeroRepository>();
builder.Services.AddScoped<MoviesRepository>();
builder.Services.AddScoped<Net14Web.DbStuff.Repositories.Movies.UserRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<WeaponRepository>();
builder.Services.AddScoped<HeroRepository>();

builder.Services.AddScoped<GameCommentRepository>();
builder.Services.AddScoped<GameShopRepository>();
builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<DividendRepository>();

// Services
builder.Services.AddScoped<CommentBuilder>();
builder.Services.AddScoped<ErrorBuilder>();
builder.Services.AddScoped<MovieBuilder>();
builder.Services.AddScoped<Net14Web.Services.Movies.UserBuilder>();
builder.Services.AddScoped<UserEditHelper>();
builder.Services.AddScoped<MovieEditHelper>();
builder.Services.AddScoped<ObjectBuilder>();
builder.Services.AddScoped<RegistrationHelper>();
builder.Services.AddScoped<CreateFilePathHelper>();
builder.Services.AddScoped<UploadFileHelper>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<DeleteUser>();
builder.Services.AddScoped<UpdateUser>();
builder.Services.AddScoped<Net14Web.Services.RealEstate.UserBuilder>();

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
