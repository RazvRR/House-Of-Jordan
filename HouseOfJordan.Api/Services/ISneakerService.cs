using HouseOfJordan.Api.Dtos;
using HouseOfJordan.Api.Models;

namespace HouseOfJordan.Api.Services
{
    public interface ISneakerService
    {
        Sneaker AddSneaker(CreateSneakerDto dto);             // POST
        Sneaker? UpdateSneaker(int id, UpdateSneakerDto dto); // PUT
    }
}
