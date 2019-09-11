using System;
using DailerApp.Models;

namespace DailerApp.AppCore.Models
{
    public class Note: IEntityModel
    {
        public int Id {get; set;}
        public string Text {get; set;}
        public DateTime Date {get; set;}
    }
}