using HouseOfJordan.Api.Data;
using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOfJordan.Api.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _context;

        public BrandService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand> CreateAsync(CreateBrandDTO dto)
        {
            var brand = new Brand
            {
                Name = dto.Name
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return brand;
        }

        public async Task<Brand?> UpdateAsync(int id, UpdateBrandDto dto)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) return null;

            if (dto.Name != null)
                brand.Name = dto.Name;

            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) return false;

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}