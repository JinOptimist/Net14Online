using Microsoft.EntityFrameworkCore;
using MoviesMicroService.SignalRHubs;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Repositories;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Services;
using Net14Web.Services.Movies;
using Net14Web.Services.Movies.Permissions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Net14WebDb");

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.SetIsOriginAllowed(url => true);
        policy.AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<MoviesRepository>();
builder.Services.AddScoped<CommentBuilder>();
builder.Services.AddScoped<MovieEditHelper>();
builder.Services.AddScoped<PermissionRepository>();
builder.Services.AddScoped<CommentPermissions>();
builder.Services.AddScoped<UserEditHelper>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<RoleRepository>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseCors();

app.MapHub<CommentHub>("/commentsMovie");

app.MapGet("/", () => "Hello World!");

app.Run();
