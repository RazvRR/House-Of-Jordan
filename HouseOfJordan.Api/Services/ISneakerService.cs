using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Models;

namespace HouseOfJordan.Api.Services
{
    public interface ISneakerService
    {
        Task<List<Sneaker>> GetAllAsync();
        Task<Sneaker?> GetByIdAsync(int id);
        Task<Sneaker> AddSneakerAsync(CreateSneakerDto dto);
        Task<Sneaker?> UpdateSneakerAsync(int id, UpdateSneakerDto dto);
        Task<bool> DeleteSneakerAsync(int id);
    }
}
