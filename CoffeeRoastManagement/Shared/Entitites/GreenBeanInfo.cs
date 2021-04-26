using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeRoastManagement.Shared.Entities
{
    [Table("GreenBeanInfo")]
    public class GreenBeanInfo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int Crop { get; set; }
        public string Processing { get; set; }
        public string Variety { get; set; }
        [Range(0,100)]
        public double OverallCuppingScore { get; set; }
        [Url]
        public string Url { get; set; }
        public string Farmer { get; set; }
        public string Note { get; set; }
    }
}
