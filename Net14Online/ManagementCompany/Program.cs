using ManagementCompany.Controllers;
using ManagementCompany.DbStuff;
using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Services;
using Microsoft.EntityFrameworkCore;

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

var connStringManagmentCompany = builder.Configuration.GetConnectionString("ManagmentCompany");

builder.Services.AddDbContext<ManagmentCompanyDbContext>(x => x.UseSqlServer(connStringManagmentCompany));

// Repositories
builder.Services.AddScoped<TaskStatusRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<ProjectRepository>();
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
    pattern: "{controller=ManagmentCompany}/{action=Index}/{id?}");

app.Run();
