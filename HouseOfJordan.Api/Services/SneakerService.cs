using HouseOfJordan.Api.Data;
using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOfJordan.Api.Services
{
    public class SneakerService : ISneakerService
    {
        private readonly AppDbContext _context;

        public SneakerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sneaker>> GetAllAsync()
        {
            return await _context.Sneakers
                .Include(s => s.Brand)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<Sneaker?> GetByIdAsync(int id)
        {
            return await _context.Sneakers
                .Include(s => s.Brand)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sneaker> AddSneakerAsync(CreateSneakerDto dto)
        {
            var sneaker = new Sneaker
            {
                BrandId = dto.BrandId,
                UserId = dto.UserId,
                Model = dto.Model,
                Colorway = dto.Colorway,
                Year = dto.Year,
                Price = dto.Price,
                Size = dto.Size
            };

            _context.Sneakers.Add(sneaker);
            await _context.SaveChangesAsync();

            // Reîncarcă sneaker-ul cu relațiile incluse
            return (await GetByIdAsync(sneaker.Id))!;
        }

        public async Task<Sneaker?> UpdateSneakerAsync(int id, UpdateSneakerDto dto)
        {
            var sneaker = await _context.Sneakers.FindAsync(id);
            if (sneaker == null)
                return null;

            if (dto.BrandId.HasValue)
                sneaker.BrandId = dto.BrandId.Value;
            if (dto.UserId.HasValue)
                sneaker.UserId = dto.UserId.Value;
            if (dto.Model != null)
                sneaker.Model = dto.Model;
            if (dto.Colorway != null)
                sneaker.Colorway = dto.Colorway;
            if (dto.Year.HasValue)
                sneaker.Year = dto.Year.Value;
            if (dto.Price.HasValue)
                sneaker.Price = dto.Price.Value;
            if (dto.Size != null)
                sneaker.Size = dto.Size;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteSneakerAsync(int id)
        {
            var sneaker = await _context.Sneakers.FindAsync(id);
            if (sneaker == null)
                return false;

            _context.Sneakers.Remove(sneaker);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
