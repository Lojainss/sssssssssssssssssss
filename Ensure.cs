namespace E_Commerce {
    public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app, IWebHostEnvironment host) {
            E_CommerceDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<E_CommerceDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                        Name = "Smart Watch",
                        Company = "Apple",
                        Genre = "Accessory",
                        Description = "The best watch ever",
                        Image = "/img/touch watch.jpg".PathToByteArray(host),
                        Price = 999.99m
                    },
                    new Product {
                        Name = "Aarphone",
                        Company = "Samsung",
                        Genre = "Accessory",
                        Description = "The best phone ever",
                        Image = "/img/earphone.jpg".PathToByteArray(host),
                        Price = 1999.99m
                    },
                    new Product {
                        Name = "AirPods",
                        Company = "Apple",
                        Genre = "Accessory",
                        Description = "The best AirPods ever",
                        Image = "/img/bluetooth headset.jpg".PathToByteArray(host),
                        Price = 11999.99m
                    },
                    new Product {
                        Name = "Clock",
                        Company = "Fastrack",
                        Genre = "Accessory",
                        Description = "The best Clock ever",
                        Image = "/img/digital clock.jpg".PathToByteArray(host),
                        Price = 1899.99m
                    },
                    new Product {
                        Name = "Clock",
                        Company = "Samsung",
                        Genre = "Accessory",
                        Description = "The best Clock ever",
                        Image = "/img/wristwatch.jpg".PathToByteArray(host),
                        Price = 8899.99m
                    },
                    new Product {
                        Name = "Sweatshirt",
                        Company = "Benetton",
                        Genre = "Clothes",
                        Description = "Navy solid sweatshirt with patchwork",
                        Image = "/img/chothes.jpg".PathToByteArray(host),
                        Price = 2599.99m
                    },
                    new Product {
                        Name = "jacket",
                        Company = "Puma",
                        Genre = "Clothes",
                        Description = "Black solid sporty jacket",
                        Image = "/img/blouse.jpg".PathToByteArray(host),
                        Price = 7999.99m
                    },
                    new Product {
                        Name = "Shoes",
                        Company = "Hush Puppies",
                        Genre = "Clothes",
                        Description = "ultimate of black coloured formal shoes ",
                        Image = "/img/shoes.jpg".PathToByteArray(host),
                        Price = 6999.99m
                    },
                    new Product {
                        Name = "Jacket",
                        Company = "BARESKIN",
                        Genre = "Clothes",
                        Description = "Black solid leather jacket",
                        Image = "/img/Womanjacket.jpg".PathToByteArray(host),
                        Price = 9999.99m
                    },
                    new Product {
                        Name = "Dress",
                        Company = "SASSAFRAS",
                        Genre = "Clothes",
                        Description = "Blue solid woven shirt dress",
                        Image = "/img/dress.jpg".PathToByteArray(host),
                        Price = 5200.99m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}