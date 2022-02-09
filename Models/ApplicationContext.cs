using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class DateApplicationContext : DbContext
    {
        //Constructor
        public DateApplicationContext(DbContextOptions<DateApplicationContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        //Seed data

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    TaskId = 1,
                    Task = "Minister to ward members",
                    DueDate = "2/28/2022",
                    Quadrant = 2,
                    Category = "Church",
                    Completed = false
                },

                new ApplicationResponse
                {
                    TaskId = 2,
                    Task = "Play video games",
                    DueDate = "2/12/2022",
                    Quadrant = 4,
                    Category = "Home",
                    Completed = true
                }
             ); 
        }
    }
}




