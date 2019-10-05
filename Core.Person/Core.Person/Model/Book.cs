using Core.Person.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Person.Model
{
    public class Book : BaseEntity
    {        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public DateTime Launchdate { get; set; }
    }
}
