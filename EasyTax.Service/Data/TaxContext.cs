using EasyTax.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyTax.Service.Data
{
    public class TaxContext : DbContext
    {
        public TaxContext(DbContextOptions<TaxContext> options)
           : base(options) { 
        }

        public DbSet<ConuntryTax> CountryTax { get; set; }
        public DbSet<TaxHistory> TaxHistory { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaxContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaxContext>>()))
            {
                if (context == null || context.CountryTax == null)
                {
                    throw new ArgumentNullException("Null TaxContext");
                }

                if (!context.CountryTax.Any())
                {
                    context.CountryTax.AddRange(
                    new ConuntryTax
                    {
                       CountryCode = "MX",
                       Tax = 16
                    }, new ConuntryTax
                    {
                        CountryCode = "US",
                        Tax = 11.2M
                    }, new ConuntryTax
                    {
                        CountryCode = "UK",
                        Tax = 18.3M
                    }, new ConuntryTax
                    {
                        CountryCode = "BR",
                        Tax = 10.4M
                    });

                    context.SaveChanges();
                }

              
            }
        }
    }
}
