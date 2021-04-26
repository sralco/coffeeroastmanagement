using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeRoastManagement.Shared.Entities
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }
        [Required]
        public GreenBeanInfo GreenBeanInfo { get; set; }
        [Required]
        public double Amount { get; set; }
        public double OverallPrice { get; set; }
        public Contact SellerContact { get; set; }
        public DateTime GoodsReceived { get; set; }
        public byte[] Photo { get; set; }
        public string Note { get; set; }
        [Required]
        public bool BeansAvailable { get; set; } = true;
    }
}
