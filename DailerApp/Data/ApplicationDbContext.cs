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
    }
}
