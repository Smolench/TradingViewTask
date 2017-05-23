using Newtonsoft.Json;
using SoftFXTestTask.EntityFramework.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftFXTestTask.EntityFramework.EntityModels
{
    public class Quote : IEntity
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "time")]
        [Required]
        public long DateTime { get; set; }
        [Required]
        public double Open { get; set; }
        [Required]
        public double High { get; set; }
        [Required]
        public double Low { get; set; }
        [Required]
        public double Close { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        [ForeignKey("Symbol")]
        public int SymbolId { get; set; }
        [Required]
        public Symbol Symbol { get; }
        public Quote()
        { }
        public Quote(Symbol symbol, DateTime datetime)
        {
            Symbol = symbol;
            long timestamp = (long)(datetime - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            DateTime = timestamp;
        }
    }
}