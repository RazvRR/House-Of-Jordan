using System.Text.Json.Serialization;
namespace HouseOfJordan.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;
        [JsonIgnore]
        // Relație 1-N: un user poate avea mai mulți sneakers
        public ICollection<Sneaker> Sneakers { get; set; } = new List<Sneaker>();
        [JsonIgnore]
        // Relație 1-N: un user poate avea mai multe items în wishlist
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
    }
}
