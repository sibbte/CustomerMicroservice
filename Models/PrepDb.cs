using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<CatContext>());
            }

        }

        public static void SeedData(CatContext context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();
            Customer customer = new Customer()
            {
                FirstName = "test",
                LastName = "test",
                Address1 = "the street",
                Address2 = "the area",
                Town = "the town",
                Postcode = "BL1 5GF",
                Email = "test@test.com",
                MobNumber = "07456987456",
                TeleNumber = "01478541236",
                Cats = 1,
                UserId = "system"

            };
            Customer customer1 = new Customer()
            {
                FirstName = "test1",
                LastName = "test1",
                Address1 = "the street",
                Address2 = "the area",
                Town = "the town",
                Postcode = "BL1 5GF",
                Email = "test1@test1.com",
                MobNumber = "07456987456",
                TeleNumber = "01478541236",
                Cats = 1,
                UserId = "system"

            };
            Customer customer2 = new Customer()
            {
                FirstName = "test2",
                LastName = "test2",
                Address1 = "the street",
                Address2 = "the area",
                Town = "the town",
                Postcode = "BL1 5GF",
                Email = "test2@test2.com",
                MobNumber = "07456987456",
                TeleNumber = "01478541236",
                Cats = 1,
                UserId = "system"

            };
            Customer customer3 = new Customer()
            {
                FirstName = "test3",
                LastName = "test3",
                Address1 = "the street",
                Address2 = "the area",
                Town = "the town",
                Postcode = "BL1 5GF",
                Email = "test3@test3.com",
                MobNumber = "07456987456",
                TeleNumber = "01478541236",
                Cats = 1,
                UserId = "system"

            };
            Customer customer4 = new Customer()
            {
                FirstName = "test4",
                LastName = "test4",
                Address1 = "the street",
                Address2 = "the area",
                Town = "the town",
                Postcode = "BL1 5GF",
                Email = "test4@test4.com",
                MobNumber = "07456987456",
                TeleNumber = "01478541236",
                Cats = 1,
                UserId = "system"

            };

            if (!context.Customers.Any())
            {
                System.Console.WriteLine("Seeding Customer Data...");
                context.Customers.AddRange(customer, customer1, customer2, customer3, customer4);

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data Customers - not seeding");
            }
        }

    }
}