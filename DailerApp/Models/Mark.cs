using System;

namespace DailerApp.Models
{
    public class Mark: IEntityModel
    {
        public int Id { get; set; }
        public DailerUser User { get; set; }
        public Trait Trait { get; set; }
        public DateTime CreationTime { get; set; }

    }
}