using System.ComponentModel.DataAnnotations;

namespace HouseOfJordan.Api.DTOs
{
    public class AddWishlistItemDto
    {
        [Required]
        public int SneakerId { get; set; }
    }
}
