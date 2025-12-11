namespace HouseOfJordan.Api.Models
{
    public class Sneaker
    {
        public int Id { get; set; }              // identificator intern
        public string Brand { get; set; } = "";  // ex: Nike
        public string Model { get; set; } = "";  // ex: Air Jordan 1
        public string Colorway { get; set; } = "";
        public int Year { get; set; }            // anul lansării
        public decimal Price { get; set; }       // prețul plătit
        public string Size { get; set; } = "";   // mărimea (ex: 42 EU)
    }
}
