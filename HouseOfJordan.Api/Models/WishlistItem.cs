using System.Text.Json.Serialization;

namespace HouseOfJordan.Api.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        // FK către User
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // FK către Sneaker
        public int SneakerId { get; set; }
        public Sneaker Sneaker { get; set; } = null!;
    }
}
