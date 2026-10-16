using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Mapping.Entities.Data
{

    class program

    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .Build();

            string ConStr = builder.GetConnectionString("ConStr");

            Console.WriteLine($"Connection String: {ConStr}");


            var context = new AppDbContext();
            foreach (var product in context.Products)
            {
                Console.WriteLine($"Product: {product.Name}");



            }
        }
    }
}