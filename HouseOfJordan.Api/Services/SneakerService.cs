using HouseOfJordan.Api.Dtos;
using HouseOfJordan.Api.Models;

namespace HouseOfJordan.Api.Services
{
    public class SneakerService : ISneakerService
    {
        // „Fake DB” în memorie
        private static readonly List<Sneaker> _sneakers = new();
        private static int _nextId = 1;

        public Sneaker AddSneaker(CreateSneakerDto dto)
        {
            var sneaker = new Sneaker
            {
                Id = _nextId++,
                Brand = dto.Brand,
                Model = dto.Model,
                Colorway = dto.Colorway,
                Year = dto.Year,
                Price = dto.Price,
                Size = dto.Size
            };

            _sneakers.Add(sneaker);
            return sneaker;
        }

        public Sneaker? UpdateSneaker(int id, UpdateSneakerDto dto)
        {
            var sneaker = _sneakers.FirstOrDefault(s => s.Id == id);
            if (sneaker == null)
                return null;

            sneaker.Brand = dto.Brand;
            sneaker.Model = dto.Model;
            sneaker.Colorway = dto.Colorway;
            sneaker.Year = dto.Year;
            sneaker.Price = dto.Price;
            sneaker.Size = dto.Size;

            return sneaker;
        }
    }
}
