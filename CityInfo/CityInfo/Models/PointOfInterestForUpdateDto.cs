using System.ComponentModel.DataAnnotations;

namespace CityInfo.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
