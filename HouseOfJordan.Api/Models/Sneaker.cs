using System.Text.Json.Serialization;
namespace HouseOfJordan.Api.Models
{
    public class Sneaker
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;
        public string Colorway { get; set; } = null!;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; } = null!;

        // Relație către Brand (FK)
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        // Relație către User (FK) - cine deține sneaker-ul
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [JsonIgnore]
        // Relație către WishlistItem (un sneaker poate apărea în wishlist la mai mulți users)
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
    }
}
