using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseOfJordan.Api.Controllers
{
    [ApiController]
    [Route("api/users/{userId:int}/wishlist")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        /// GET /api/users/{userId}/wishlist - listare articole din wishlist
        [HttpGet]
        public async Task<IActionResult> GetWishlist(int userId)
        {
            var items = await _wishlistService.GetForUserAsync(userId);
            return Ok(items);
        }

        /// POST /api/users/{userId}/wishlist - adăugare sneaker în wishlist
        [HttpPost]
        public async Task<IActionResult> AddToWishlist(int userId, [FromBody] AddWishlistItemDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _wishlistService.AddForUserAsync(userId, dto);
            if (created == null)
            {
                return BadRequest(new { message = "UserId sau SneakerId invalid (nu există în DB)." });
            }

            return Ok(created);
        }

        /// DELETE /api/users/{userId}/wishlist/{itemId} - ștergere articol din wishlist
        [HttpDelete("{itemId:int}")]
        public async Task<IActionResult> Delete(int userId, int itemId)
        {
            var ok = await _wishlistService.DeleteAsync(userId, itemId);
            if (!ok) return NotFound(new { message = "Wishlist item nu a fost găsit pentru acest user." });

            return NoContent();
        }
    }
}
