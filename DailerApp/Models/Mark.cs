using System;

namespace DailerApp.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public DailerUser User { get; set; }
        public Trait Trait { get; set; }
        public DateTime CreationTime { get; set; }

    }
}