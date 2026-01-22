using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Models;

namespace HouseOfJordan.Api.Services
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(CreateBrandDTO dto);
        Task<Brand?> UpdateAsync(int id, UpdateBrandDto dto);
        Task<bool> DeleteAsync(int id);
    }
}