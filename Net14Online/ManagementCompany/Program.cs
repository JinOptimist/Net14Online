using ManagementCompany.Controllers;
using ManagementCompany.DbStuff;
using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Services;
using ManagementCompany.SignalRHubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(AuthController.AUTH_KEY_MC)
    .AddCookie(AuthController.AUTH_KEY_MC, option =>
    {
        option.AccessDeniedPath = "/auth/deny";
        option.LoginPath = "/Auth/Login";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var connStringManagementCompany = builder.Configuration.GetConnectionString("ManagementCompany");

builder.Services.AddDbContext<ManagementCompanyDbContext>(x => x.UseSqlServer(connStringManagementCompany));

// Repositories
builder.Services.AddSignalR();
builder.Services.AddScoped<TaskStatusRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<ArticleRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserTaskRepository>();
builder.Services.AddScoped<MemberPermissionRepository>();
builder.Services.AddScoped<MemberStatusRepository>();

// Services
builder.Services.AddScoped<CreateFilePathHelper>();
builder.Services.AddScoped<UploadFileHelper>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

SeedExtention.Seed(app);

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

app.MapHub<BlogHub>("/Blog");

//app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ManagementCompany}/{action=Index}/{id?}");

app.Run();
