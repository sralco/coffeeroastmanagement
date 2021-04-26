using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeRoastManagement.Shared.Entities
{
    [Table("Contact")]
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        [Url]
        public string Url { get; set; }
        public byte[] FavIcon { get; set; }
        public string Note { get; set; }
    }
}
