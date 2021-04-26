using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeRoastManagement.Shared.Entities
{
    [Table("GreenBlend")]
    public class GreenBlend
    {
        public int Id { get; set; }
        [Required]
        public Stock StockItem { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
