using System.ComponentModel.DataAnnotations;

namespace CarsStore.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
    }
}
