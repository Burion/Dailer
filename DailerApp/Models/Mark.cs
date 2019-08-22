using System;
using System.ComponentModel.DataAnnotations;

namespace DailerApp.Models
{
    public class Mark: IEntityModel
    {
        public int Id { get; set; }
        public DailerUser User { get; set; }
        public Trait Trait { get; set; }
        public DateTime CreationTime { get; set; }
        [Range(1, 5, ErrorMessage = "Please, enter valid value")]
        public int Value { get; set; }

    }
}