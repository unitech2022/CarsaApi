
using carsaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace carsaApi.Data
{



    public class CarsaApiContext : IdentityDbContext<User>
    {

        public CarsaApiContext(DbContextOptions<CarsaApiContext> otp) : base(otp)
        {

        }





        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<WorkshopCategory> WorkCategories { get; set; }


        public DbSet<Product> Products { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Need> Needs { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

public DbSet<Sitting> Sittings { get; set; }

        public DbSet<Address> Addresses { get; set; }


         public DbSet<Workshop> Workshops { get; set; }

           public DbSet<CarModel> CarModels { get; set; }

         public DbSet<Rate> Rets { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Driver_Field> Driver_Fields { get; set; }
        public DbSet<Driver_Order> Driver_Orders { get; set; }
        public DbSet<Support> Supports { get; set; }
        internal object Where(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
        public DbSet<Suggestions> Suggestionses { get; set; }

        // public DbSet<SubCategory> SubCategories { get; set; }

        // public DbSet<Adds> Adds { get; set; }
    }

}