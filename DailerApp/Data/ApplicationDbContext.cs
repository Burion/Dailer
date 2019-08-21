using System;
using System.Collections.Generic;
using System.Text;
using DailerApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            builder.Entity<Trait>().HasData(
                new Trait(){ Title = "Family", Description = "Take care of it" }, 
                new Trait(){ Title = "Friends", Description = "Spend time with them" },
                new Trait(){ Title = "Health", Description = "Don't lost it" },  
                new Trait(){ Title = "Hobby", Description = "It's your personal antidepressant" },
                new Trait(){ Title = "Self-improvement", Description = "You are not snowflake" },
                new Trait(){ Title = "Carreer", Description = "I bet you don't want to be cleaner at your middle age" }, 
                new Trait(){ Title = "Money", Description = "Whatever you would say, it's material world" },
                new Trait(){ Title = "Rest", Description = "You won't work hard if you don't play hard" }
            );
        }
    }
}
