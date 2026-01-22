using System.ComponentModel.DataAnnotations;

namespace HouseOfJordan.Api.DTOs
{
    public class UpdateSneakerDto
    {
        public string? Model { get; set; }
        public string? Colorway { get; set; }

        [Range(1900, 2100)]
        public int? Year { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; set; }

        public string? Size { get; set; }
        public int? BrandId { get; set; }
        public int? UserId { get; set; }
    }
}

