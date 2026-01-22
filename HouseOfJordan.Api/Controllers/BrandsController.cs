using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseOfJordan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        /// GET /api/brands - listare branduri
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }

        /// GET /api/brands/{id} - detalii brand
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
                return NotFound(new { message = $"Brand cu id={id} nu a fost găsit." });

            return Ok(brand);
        }

        /// POST /api/brands - creare brand
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _brandService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// PUT /api/brands/{id} - actualizare brand
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBrandDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _brandService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = $"Brand cu id={id} nu a fost găsit." });

            return Ok(updated);
        }

        /// DELETE /api/brands/{id} - ștergere brand
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _brandService.DeleteAsync(id);
            if (!ok)
                return NotFound(new { message = $"Brand cu id={id} nu a fost găsit." });

            return NoContent();
        }
    }
}