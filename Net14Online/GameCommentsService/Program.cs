using GameCommentsService.Database;
using GameCommentsService.Hubs;

namespace GameCommentsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<FakeDb>();

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

            var app = builder.Build();

            app.UseCors();

            app.MapHub<CommentHub>("/comments");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
