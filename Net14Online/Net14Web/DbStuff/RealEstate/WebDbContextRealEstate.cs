using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.RealEstate.Models;

namespace Net14Web.DbStuff.RealEstate;

public class WebDbContextRealEstate : DbContext
{
    protected readonly IConfiguration Configuration;

    public WebDbContextRealEstate(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
    
    public DbSet<ApartmentOwner> ApartmentOwners { get; set; } 
}