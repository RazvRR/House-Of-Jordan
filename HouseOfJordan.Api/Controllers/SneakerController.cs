using HouseOfJordan.Api.DTOs;
using HouseOfJordan.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseOfJordan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SneakersController : ControllerBase
    {
        private readonly ISneakerService _sneakerService;

        public SneakersController(ISneakerService sneakerService)
        {
            _sneakerService = sneakerService;
        }


        /// GET /api/sneakers - listare sneakers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sneakers = await _sneakerService.GetAllAsync();
            return Ok(sneakers);
        }

        /// GET /api/sneakers/{id} - detalii sneaker
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sneaker = await _sneakerService.GetByIdAsync(id);
            if (sneaker == null)
                return NotFound(new { message = $"Sneaker cu id={id} nu a fost găsit." });

            return Ok(sneaker);
        }

        /// POST /api/sneakers - creare sneaker
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSneakerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _sneakerService.AddSneakerAsync(dto);

            // întoarce 201 + location către GET by id
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// PUT /api/sneakers/{id} - actualizare sneaker
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSneakerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _sneakerService.UpdateSneakerAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = $"Sneaker cu id={id} nu a fost găsit." });

            return Ok(updated);
        }

        /// DELETE /api/sneakers/{id} - ștergere sneaker
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _sneakerService.DeleteSneakerAsync(id);
            if (!ok)
                return NotFound(new { message = $"Sneaker cu id={id} nu a fost găsit." });

            return NoContent();
        }
    }
}
