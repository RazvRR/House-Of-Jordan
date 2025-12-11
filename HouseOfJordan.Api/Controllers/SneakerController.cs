using HouseOfJordan.Api.Dtos;
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

        /// <summary>
        /// US1 – Adăugare sneaker
        /// POST /api/sneakers
        /// </summary>
        [HttpPost]
        public IActionResult AddSneaker([FromBody] CreateSneakerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _sneakerService.AddSneaker(dto);
            return CreatedAtAction(nameof(GetSneaker), new { id = created.Id }, created);
        }

        // helper pentru CreatedAtAction (nu e în US, dar e util)
        [HttpGet("{id:int}")]
        public IActionResult GetSneaker(int id)
        {
            return Ok(new { Message = $"Sneaker with id={id} would be returned here (demo)." });
        }

        /// <summary>
        /// US2 – Actualizare sneaker
        /// PUT /api/sneakers/{id}
        /// </summary>
        [HttpPut("{id:int}")]
        public IActionResult UpdateSneaker(int id, [FromBody] UpdateSneakerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _sneakerService.UpdateSneaker(id, dto);

            if (updated == null)
                return NotFound(new { message = $"Sneaker cu id={id} nu a fost găsit." });

            return Ok(updated);
        }
    }
}
