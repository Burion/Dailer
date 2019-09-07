using System;
using System.Collections.Generic;
using System.Text;
using DailerApp.Models;
using DailerApp.AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DailerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<DailerUser>
    {

        public DbSet<Trait> Traits {get; set;}
        public DbSet<Mark> Marks {get; set;}
        
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Trait>().HasData(
                new Trait(){ Id = 1, Title = "Family", Description = "Take care of it" }, 
                new Trait(){ Id = 2, Title = "Friends", Description = "Spend time with them" },
                new Trait(){ Id = 3, Title = "Health", Description = "Don't lost it" },  
                new Trait(){ Id = 4, Title = "Hobby", Description = "It's your personal antidepressant" },
                new Trait(){ Id = 5, Title = "Self-improvement", Description = "You are not snowflake" },
                new Trait(){ Id = 6, Title = "Carreer", Description = "I bet you don't want to be cleaner at your middle age" }, 
                new Trait(){ Id = 7, Title = "Money", Description = "Whatever you would say, it's material world" },
                new Trait(){ Id = 8, Title = "Rest", Description = "You won't work hard if you don't play hard" }
            );
        }

       
    }
}
