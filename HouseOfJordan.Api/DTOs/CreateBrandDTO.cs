using System.ComponentModel.DataAnnotations;

namespace HouseOfJordan.Api.DTOs
{
    public class CreateBrandDTO
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}