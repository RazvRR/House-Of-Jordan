using System.ComponentModel.DataAnnotations;

namespace HouseOfJordan.Api.DTOs
{
    public class UpdateBrandDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
