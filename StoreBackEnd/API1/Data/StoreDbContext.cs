using API1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API1.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            CreateIfEmpty();
        }
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<Orders> Orders { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<VideoCart> Videocarts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.HasIndex(e => e.Email, "user_login_key")
                   .IsUnique();
                entity.Property(e => e.Email)
                   .HasMaxLength(30)
                   .HasColumnName("login");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.HasOne(p => p.User)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<VideoCart>(entity =>
            {
                entity.ToTable("Videocart");

                entity.HasIndex(e => e.NameProduct, "product_videocart_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");


                entity.Property(e => e.NameProduct)
                    .HasMaxLength(30)
                    .HasColumnName("name_product");
                entity.HasOne(p => p.Category)
                    .WithMany(t => t.VideoCarts)
                    .HasForeignKey(p => p.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Price).HasColumnName("price");

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders");

                entity.Property(e => e.Id).HasColumnName("Id");
            });
        }


        private void CreateIfEmpty()
        {
            if (Database.EnsureCreated())
            {
                var cat = new Category { Name = "GIGABYTE" };
                var cat1 = new Category { Name = "ASUS" };


                var videog = new VideoCart
                {
                    Category = cat,
                    NameProduct = "GIGABYTE GeForce RTX 3060",
                    Price = 25866,
                    Img = "https://hotline.ua/img/tx/284/284852339_s265.jpg"
                };
                var video1g = new VideoCart
                {
                    Category = cat,
                    
                    NameProduct = "GIGABYTE GeForce RTX 3070",
                    Price = 37700,
                    Img = "https://hotline.ua/img/tx/282/282942323_s265.jpg"
                };
                var video2g = new VideoCart
                {
                    Category = cat,
                    
                    NameProduct = "GIGABYTE GeForce RTX 3080",
                    Price = 42700,
                    Img = "https://hotline.ua/img/tx/300/300868961_s265.jpg"
                };
                var video3g = new VideoCart
                {
                    Category = cat,
                    
                    NameProduct = "GIGABYTE GeForce RTX 3090",
                    Price = 50720,
                    Img = "https://hotline.ua/img/tx/236/236802803_s265.jpg"
                };

                var videoa = new VideoCart
                {
                    Category = cat1,
                    
                    NameProduct = "ASUS GeForce RTX 3060",
                    Price = 27866,
                    Img = "https://hotline.ua/img/tx/289/289729776_s265.jpg"
                };
                var video1a = new VideoCart
                {
                    Category = cat1,
                    
                    NameProduct = "ASUS GeForce RTX 3070",
                    Price = 36660,
                    Img = "https://hotline.ua/img/tx/283/283140768_s265.jpg"
                };
                var video2a = new VideoCart
                {
                    Category = cat1,
                    
                    NameProduct = "ASUS GeForce RTX 3080",
                    Price = 42700,
                    Img = "https://hotline.ua/img/tx/294/294960059_s265.jpg"
                };
                var video3a = new VideoCart
                {
                    Category = cat1,
                    
                    NameProduct = "ASUS GeForce RTX 3090",
                    Price = 50700,
                    Img = "https://hotline.ua/img/tx/238/238304963_s265.jpg"
                };



                var cat2 = new Category { Name = "Palit" };


                var videop = new VideoCart
                {
                    Category = cat2,
                    
                    NameProduct = "Palit GeForce RTX 3060",
                    Price = 24866,
                    Img = "https://hotline.ua/img/tx/322/322393285_s265.jpg"
                };
                var video1p = new VideoCart
                {
                    Category = cat2,
                    
                    NameProduct = "Palit GeForce RTX 3070",
                    Price = 37660,
                    Img = "https://hotline.ua/img/tx/282/282630067_s265.jpg"
                };
                var video2p = new VideoCart
                {
                    Category = cat2,
                    
                    NameProduct = "Palit GeForce RTX 3080",
                    Price = 43700,
                    Img = "https://hotline.ua/img/tx/321/321562084_s265.jpg"
                };
                var video3p = new VideoCart
                {
                    Category = cat2,
                    
                    NameProduct = "Palit GeForce RTX 3090",
                    Price = 51700,
                    Img = "https://hotline.ua/img/tx/236/236819076_s265.jpg"
                };

                var cat3 = new Category { Name = "MSI" };

                var videom = new VideoCart
                {
                    Category = cat3,
                    
                    NameProduct = "MSI GeForce RTX 3060",
                    Price = 22866,
                    Img = "https://hotline.ua/img/tx/265/265996220_s265.jpg"
                };
                var video1m = new VideoCart
                {
                    Category = cat3,
                    
                    NameProduct = "MSI GeForce RTX 3070",
                    Price = 38660,
                    Img = "https://hotline.ua/img/tx/286/286738254_s265.jpg"
                };
                var video2m = new VideoCart
                {
                    Category = cat3,
                    
                    NameProduct = "MSI GeForce RTX 3080",
                    Price = 45700,
                    Img = "https://hotline.ua/img/tx/282/282630430_s265.jpg"
                };
                var video3m = new VideoCart
                {
                    Category = cat3,
                    
                    NameProduct = "MSI GeForce RTX 3090",
                    Price = 55700,
                    Img = "https://hotline.ua/img/tx/236/236802765_s265.jpg"
                };

                Videocarts.AddRange(new List<VideoCart> { videog, video1g, video2g, video3g });
                Videocarts.AddRange(new List<VideoCart> { videoa, video1a, video2a, video3a });
                Videocarts.AddRange(new List<VideoCart> { videom, video1m, video2m, video3m });
                Videocarts.AddRange(new List<VideoCart> { videop, video1p, video2p, video3p });
                
                Users.Add(
                    new User
                    {
                        Email = "admin@gmail.com",
                    });
                Users.Add(
                    new User
                    {
                        Email = "user@gmail.com",
                    });
                SaveChanges();
                Order.Add(new Order {
                    UserId = 2,
                    Orders = new List<Orders>
                    {
                        new Orders { 
                            VideoCartId = 1,
                            Quantity = 1,
                        },
                        new Orders { 
                            VideoCartId = 6,
                            Quantity = 2,
                        },
                        new Orders { 
                            VideoCartId = 2,
                            Quantity = 5,
                        },
                        new Orders { 
                            VideoCartId = 8,
                            Quantity = 3,
                        }
                    }
                    });
                //Carts.Add();

                SaveChanges();
            }
        }
    }
    
}
