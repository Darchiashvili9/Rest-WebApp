using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (context.Products.Count() == 0 && context.Suppliers.Count() == 0 && context.Categories.Count() == 0)
            {
                Supplier s1 = new Supplier
                {
                    Name = "Ballers",
                    City = "Moscow"
                };
                Supplier s2 = new Supplier
                {
                    Name = "TennisGirls",
                    City = "Stuttgart"
                };
                Supplier s3 = new Supplier
                {
                    Name = "FitnessBodySuperFlash",
                    City = "Tbilisi"
                };

                Category c1 = new Category { Name = "Football" };
                Category c2 = new Category { Name = "Tennis" };
                Category c3 = new Category { Name = "Fitness" };

                context.Products.AddRange(
                    new Product { Name = "ball", Category = c1, Supplier = s1 },
                    new Product { Name = "RealMadridShirt", Category = c1, Supplier = s1 },
                    new Product { Name = "TennisBall", Category = c2, Supplier = s2 },
                    new Product { Name = "Shirt", Category = c2, Supplier = s2 },
                    new Product { Name = "Rocket", Category = c2, Supplier = s2 },
                    new Product { Name = "Bench", Category = c3, Supplier = s3 },
                    new Product { Name = "Barbell", Category = c3, Supplier = s3 },
                    new Product { Name = "Weights", Category = c3, Supplier = s3 },
                    new Product { Name = "PowerCage", Category = c3, Supplier = s3 },
                    new Product { Name = "BenchPress", Category = c3, Supplier = s3 }
                    );
            }
            context.SaveChanges();
        }
    }
}
