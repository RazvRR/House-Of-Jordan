using System.ComponentModel.DataAnnotations;

namespace HouseOfJordan.Api.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; } = null!;
    }
}
