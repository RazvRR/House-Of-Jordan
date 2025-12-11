namespace HouseOfJordan.Api.Dtos
{
    public class CreateSneakerDto
    {
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string Colorway { get; set; } = "";
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; } = "";
    }
}
