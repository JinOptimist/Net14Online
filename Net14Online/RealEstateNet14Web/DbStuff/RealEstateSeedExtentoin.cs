using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;

namespace RealEstateNet14Web.DbStuff;

public class RealEstateSeedExtentoin
{
    public static void Seed(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            SeedUser(serviceScope.ServiceProvider);
        }
    }
    private static void SeedUser(IServiceProvider serviceProvider)
    {
        var apartmentOwnerRepository = serviceProvider.GetService<RealEstateOwnerRepository>();
        if (!apartmentOwnerRepository.AnyUserWithName("admin"))
        {
            var admin = new RealEstateOwner()
            {
                Login = "admin",
                Password = "123",
                Email = "test@test.com",
            };

            apartmentOwnerRepository.Add(admin);
        }
    }
}