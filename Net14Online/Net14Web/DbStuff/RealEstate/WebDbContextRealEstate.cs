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
        options.UseNpgsql(Configuration.GetConnectionString("Net14WebRE"));
    }
    
    public DbSet<ApartmentOwner> ApartmentOwners { get; set; }
    public DbSet<Apartament> Apartaments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Apartament>()
            .HasOne(apartament => apartament.ApartmentOwner)
            .WithMany(apartmentOwner => apartmentOwner.Apartaments)
            .OnDelete(DeleteBehavior.NoAction);
        base.OnModelCreating(builder);
    }
}