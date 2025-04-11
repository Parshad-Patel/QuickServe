using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickServe.Models;

namespace QuickServe.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });
            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Appetizer" },
                    new Category { CategoryId = 2, Name = "main dish" },
                    new Category { CategoryId = 3, Name = "Side Dish" },
                    new Category { CategoryId = 4, Name = "Dessert" },
                    new Category { CategoryId = 5, Name = "drink" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                    new Ingredient { IngredientId = 1, Name = "Masala" },
                    new Ingredient { IngredientId = 2, Name = "Dahi" },
                    new Ingredient { IngredientId = 3, Name = "Paneer" },
                    new Ingredient { IngredientId = 4, Name = "chesse" },
                    new Ingredient { IngredientId = 5, Name = "Vegetable" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1,
                    Name = "Paneer Tikka",
                    Description = "Paneer Tikka is a popular Indian appetizer made with marinated paneer (Indian cottage cheese) cubes, grilled or baked to perfection. The paneer is typically marinated in a mixture of yogurt and spices, giving it a flavorful and smoky taste.",
                    Price = 10.99m,
                    Stock = 50,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Paneer Butter Masala",
                    Description = "Paneer Butter Masala is a rich and creamy North Indian dish made with paneer (Indian cottage cheese) cooked in a luscious tomato-based gravy. The dish is known for its buttery flavor and is often enjoyed with naan or rice.",
                    Price = 12.99m,
                    Stock = 30,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Paneer Biryani",
                    Description = "Paneer Biryani is a fragrant and flavorful rice dish made with basmati rice, paneer (Indian cottage cheese), and a blend of aromatic spices. It is a one-pot meal that is often garnished with fried onions and served with raita.",
                    Price = 14.99m,
                    Stock = 20,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Coco Milk",
                    Description = "Coco Milk is a refreshing and creamy beverage made from the milk of coconuts. It is often used in tropical drinks and desserts, providing a rich coconut flavor.",
                    Price = 3.99m,
                    Stock = 100,
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Coconut Water",
                    Description = "Coconut Water is a natural, hydrating beverage found inside young green coconuts. It is known for its refreshing taste and is often consumed as a healthy drink.",
                    Price = 2.99m,
                    Stock = 150,
                    CategoryId = 5
                }
             );
            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 3 },
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 2, IngredientId = 3 },
                new ProductIngredient { ProductId = 2, IngredientId = 1 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 1 },
                new ProductIngredient { ProductId = 4, IngredientId = 4 },
                new ProductIngredient { ProductId = 4, IngredientId = 5 },
                new ProductIngredient { ProductId = 5, IngredientId = 4 },
                new ProductIngredient { ProductId = 5, IngredientId = 5 }

            );
        }
    }
}