using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff;

public class WebRealEstateDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public WebRealEstateDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("Net14WebRE"));
    }
    
    public DbSet<RealEstateOwner> RealEstateOwners { get; set; } 
    
    public DbSet<RealEstate> RealEstates { get; set; }
    
    public DbSet<Alert> Alerts { get; set; }
    
     protected override void OnModelCreating(ModelBuilder builder)
     {
            base.OnModelCreating(builder);

            builder.Entity<Alert>()
                .HasMany(user => user.NotificatedRealEstateOwners)
                .WithMany(alert => alert.SeenAlerts);

            builder.Entity<Alert>()
                .HasOne(user => user.Creator)
                .WithMany(alert => alert.CreatedAlerts)
                .OnDelete(DeleteBehavior.NoAction);
     }
}