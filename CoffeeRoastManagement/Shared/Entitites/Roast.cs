using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeRoastManagement.Shared.Entities
{
    [Table("Roast")]
    public class Roast
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortInfo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public List<GreenBlend> Beans { get; set; }
        public string Equipment { get; set; }
        public Cupping CuppingInfo { get; set; }
        [Column(TypeName = "jsonb")]
        public string RoastProfile { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
    }
}
