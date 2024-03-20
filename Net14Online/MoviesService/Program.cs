using CommentMoviesMicroService.DbStuff;
using CommentMoviesMicroService.DbStuff.Repositories;
using CommentMoviesMicroService.Services;
using CommentMoviesMicroService.SignalRHubs;
using Microsoft.EntityFrameworkCore;

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


builder.Services.AddDbContext<CommentWebDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<CommentBuilder>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseCors();

app.MapHub<CommentHub>("/commentsMovie");

app.MapGet("/", () => "Micro Sevice movies comment start!");

app.Run();
