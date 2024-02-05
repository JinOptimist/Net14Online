using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.RealEstate.Models;

namespace Net14Web.DbStuff.RealEstate;

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
    
    public DbSet<ApartmentOwner> ApartmentOwners { get; set; } 
}