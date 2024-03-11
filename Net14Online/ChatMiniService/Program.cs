using ChatMiniService.DbStuff;
using ChatMiniService.FluentValidators;
using ChatMiniService.Middlewares;
using ChatMiniService.Services;
using ChatMiniService.SignalRHubs;
using ChatMiniService.ViewModels;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<FakeDb>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IValidator<MessageViewModel>, MessageViewModelValidator>();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        //policy.WithHeaders("Smile", "Credential");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.SetIsOriginAllowed(url => true);
        policy.AllowCredentials();
    });
});
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors();

app.UseMiddleware<ChatAuthMiddleware>();

app.MapHub<ChatHub>("/chat");

app.MapGet("/", () => "Hello World!");

app.Run();
