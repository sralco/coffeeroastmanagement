using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeRoastManagement.Shared.Entities
{
    [Table("Cupping")]
    public class Cupping
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }
        public string Note { get; set; }
    }
}
