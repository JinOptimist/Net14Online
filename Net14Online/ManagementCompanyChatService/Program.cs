using ManagementCompanyChatService.DbStuff;
using ManagementCompanyChatService.SignalRHubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

var connStringChatMc = builder.Configuration.GetConnectionString("ManagementCompanyChat");

builder.Services.AddDbContext<ChatDbContext>(x => x.UseSqlServer(connStringChatMc));

var app = builder.Build();

app.UseCors();

app.MapHub<BlogHub>("/Blog");

app.MapGet("/", () => "Hello World!");

app.Run();
