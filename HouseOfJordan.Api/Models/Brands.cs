using System.Text.Json.Serialization;

namespace HouseOfJordan.Api.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        // Relație către Sneakers (un brand poate avea mai mulți sneakers)
        public ICollection<Sneaker> Sneakers { get; set; } = new List<Sneaker>();
    }
}