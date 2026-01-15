using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Models;

namespace HouseOfJordan.Api.Services
{
    public interface IWishlistService
    {
        Task<List<WishlistItem>> GetForUserAsync(int userId);
        Task<WishlistItem?> AddForUserAsync(int userId, AddWishlistItemDto dto);
        Task<bool> DeleteAsync(int userId, int itemId);
    }
}
