using ManagementCompanyChatService.SignalRHubs;

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

var app = builder.Build();

app.UseCors();

app.MapHub<BlogHub>("/Blog");

app.MapGet("/", () => "Hello World!");

app.Run();
