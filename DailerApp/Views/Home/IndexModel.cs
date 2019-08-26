
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailerApp.Models
{
    public class IndexModel 
    {
        public string Title {get; set;}
        public List<Trait> Traits { get; set; }
        public int[] Data {get; set;} 
    }
}