using SoftFXTestTask.EntityFramework.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftFXTestTask.EntityFramework.EntityModels
{
    public class Symbol : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
        public Symbol()
        {
            Quotes = new List<Quote>();
        }
    }
}