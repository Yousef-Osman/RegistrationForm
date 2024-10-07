using Microsoft.EntityFrameworkCore;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Persistence.Data;
public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await SeedGovernatesAndCities(context);

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
    }

    private static async Task SeedGovernatesAndCities(AppDbContext context)
    {
        if (await context.Governates.AnyAsync())
            return;

        var types = new List<Governate>
        {
            new Governate 
            {
                Name = "Cairo",
                Cities = new List<City>
                {
                    new City { Name = "5th Settlement" },
                    new City { Name = "Ain Shams" },
                    new City { Name = "Maadi" },
                }
            },
            new Governate 
            { 
                Name = "Alexandria",
                Cities = new List<City>
                {
                    new City { Name = "El Montaza"},
                    new City { Name = "Moharam Bek" },
                    new City { Name = "Sidi Gaber" },
                }
            },
            new Governate 
            { 
                Name = "Giza",
                Cities = new List<City>
                {
                    new City { Name = "Dokki" },
                    new City { Name = "Pyramids" },
                    new City { Name = "Agouza" },
            
                }
            },
            new Governate 
            { 
                Name = "Aswan",
                Cities = new List<City>
                {
                    new City { Name = "Abu Simbel" },
                    new City { Name = "Edfu" },
                    new City { Name = "Kom Ombo"},
                }
            },
            new Governate 
            { 
                Name = "Luxor",
                Cities = new List<City>
                {
                    new City { Name = "Qurna" },
                    new City { Name = "Armant" },
                    new City { Name = "Thebes " },
                }
            },
        };

        context.Governates.AddRange(types);
    }
}
