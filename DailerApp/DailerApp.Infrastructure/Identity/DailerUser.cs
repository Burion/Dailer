

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace DailerApp.Models
{
    public class DailerUser: IdentityUser
    {
        public string Login {get; set;}
        public int Expierence {get; set;}
        public virtual List<Mark> Marks { get; set; }
    }
}