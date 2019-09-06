using System;

namespace DailerApp.Models
{
    public class Trait: IEntityModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description {get; set;}
        
    }
}