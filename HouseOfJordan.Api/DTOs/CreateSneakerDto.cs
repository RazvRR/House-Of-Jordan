using System.ComponentModel.DataAnnotations;

namespace HouseOfJordan.Api.DTOs
{
    public class CreateSneakerDto
    {
        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public string Colorway { get; set; } = null!;

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Size { get; set; } = null!;

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}

