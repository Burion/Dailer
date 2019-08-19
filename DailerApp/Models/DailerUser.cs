

using Microsoft.AspNetCore.Identity;

namespace DailerApp.Models
{
    public class DailerUser: IdentityUser
    {
        public string Login {get; set;}
        
    }
}