using HouseOfJordan.Api.Data;
using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOfJordan.Api.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly AppDbContext _context;

        public WishlistService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WishlistItem>> GetForUserAsync(int userId)
        {
            // Include Sneaker + Brand pentru a afișa wishlist-ul
            return await _context.WishlistItems
                .Where(w => w.UserId == userId)
                .Include(w => w.Sneaker)
                    .ThenInclude(s => s.Brand)
                .ToListAsync();
        }

        public async Task<WishlistItem?> AddForUserAsync(int userId, AddWishlistItemDto dto)
        {
            // Verifică dacă user există
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists) return null;

            // Verifică dacă sneaker există
            var sneakerExists = await _context.Sneakers.AnyAsync(s => s.Id == dto.SneakerId);
            if (!sneakerExists) return null;

            // Nu permite duplicate
            var alreadyExists = await _context.WishlistItems
                .AnyAsync(w => w.UserId == userId && w.SneakerId == dto.SneakerId);

            if (alreadyExists)
            {
                // îl returnăm pe cel existent ca să nu crape cu Unique constraint
                return await _context.WishlistItems
                    .Include(w => w.Sneaker).ThenInclude(s => s.Brand)
                    .FirstAsync(w => w.UserId == userId && w.SneakerId == dto.SneakerId);
            }

            var item = new WishlistItem
            {
                UserId = userId,
                SneakerId = dto.SneakerId
            };

            _context.WishlistItems.Add(item);
            await _context.SaveChangesAsync();

            // Reîncarcă cu include pentru response
            return await _context.WishlistItems
                .Include(w => w.Sneaker)
                    .ThenInclude(s => s.Brand)
                .FirstAsync(w => w.Id == item.Id);
        }

        public async Task<bool> DeleteAsync(int userId, int itemId)
        {
            var item = await _context.WishlistItems
                .FirstOrDefaultAsync(w => w.Id == itemId && w.UserId == userId);

            if (item == null) return false;

            _context.WishlistItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
