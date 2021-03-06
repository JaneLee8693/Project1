using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class ApplicationContext : DbContext
    {
        //Constructor
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> Response { get; set; }

        public DbSet<Category> Category { get; set; }


        //Seed data as default (we want to see it as a test. The data may be changed afterwards)
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Home" },
                    new Category { CategoryId = 2, CategoryName = "School" },
                    new Category { CategoryId = 3, CategoryName = "Work" },
                    new Category { CategoryId = 4, CategoryName = "Church" }
                );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    TaskId = 1,
                    CategoryId = 4,
                    Task = "Minister to ward members",
                    Quadrant = 2,
                    Completed = false
                },

                new ApplicationResponse
                {
                    TaskId = 2,
                    CategoryId = 1,
                    Task = "Play video games",
                    Quadrant = 4,
                    Completed = true
                }
             ); 
        }
    }
}




