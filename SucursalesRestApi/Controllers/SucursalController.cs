using Microsoft.AspNetCore.Mvc;
using SucursalesRestApi.Models;
using SucursalesRestApi.Models.Repository;

namespace SucursalesRestApi.Controllers
{
    [Route("sucursales/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private ISucursaleRepository _sucursaleRepository;

        public SucursalController (ISucursaleRepository sucursaleRepository)
        {
            _sucursaleRepository = sucursaleRepository;
        }


        [HttpGet]
        [ActionName(nameof(GetSucursalesAsync))]
        public IEnumerable<Sucursales> GetSucursalesAsync()
        {
            return (IEnumerable<Sucursales>)_sucursaleRepository.GetSucursales();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetSucursalesById))]
        public ActionResult<Sucursales> GetSucursalesById(int id)
        {
            var sucursalesByID = _sucursaleRepository.GetSucursalesById(id);
            if (sucursalesByID == null)
            {
                return NotFound();
            }
            return sucursalesByID;
        }

    

        [HttpPost]
        [ActionName(nameof(CreateSucursalesAsync))]
        public async Task<ActionResult<Sucursales>> CreateSucursalesAsync(Sucursales sucursales)
        {
            await _sucursaleRepository.CreateSucursalAsync(sucursales);
            return CreatedAtAction(nameof(GetSucursalesById), new { id = sucursales.id }, sucursales);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateSucursales))]
        public async Task<ActionResult> UpdateSucursales(int id, Sucursales sucursales)
        {
            if (id != sucursales.id)
            {
                return BadRequest();
            }

            await _sucursaleRepository.UpdateSucursalessAsync(sucursales);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteSucursales))]
        public async Task<IActionResult> DeleteSucursales(int id)
        {
            var sucursal = _sucursaleRepository.GetSucursalesById(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            await _sucursaleRepository.DeleteSucursalesAsync(sucursal);

            return NoContent();
        }
    }
}
