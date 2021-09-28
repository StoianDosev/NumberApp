using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using System.Collections.Generic;
using Data.Models;
using Data.Context;

namespace NumbersApp
{
    public class InitialDb
{
    public static void Populate(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<InMemoryDbContext>());
        }
        
    }

    private static void SeedData(InMemoryDbContext context)
    {
        System.Console.WriteLine("Starting migration...");
        

        if(!context.Numbers.Any())
        {
            context.Numbers.AddRange(
                new List<Number>()
                {
                    new Number(){Value=123},
                    new Number(){Value=231},
                    new Number(){Value=324},
                    new Number(){Value=241},
                    new Number(){Value=321},
                    new Number(){Value=434},
                }
            );

            context.SaveChanges();
        }
        

        System.Console.WriteLine("Finish");
    }
}
}
