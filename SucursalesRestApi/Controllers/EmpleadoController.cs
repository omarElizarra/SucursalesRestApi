using Microsoft.AspNetCore.Mvc;
using SucursalesRestApi.Models;
using SucursalesRestApi.Models.Repository;

namespace SucursalesRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private IEmpleadoRepository _empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEmpleadosAsync))]
        public IEnumerable<Empleados> GetEmpleadosAsync()
        {
            return _empleadoRepository.GetEmpleados();
        }
        
        [HttpGet("{id}")]
        [ActionName(nameof(GetEmpleadosById))]
        public ActionResult<Empleados> GetEmpleadosById(string id)
        {
            var empleadoByID = _empleadoRepository.GetEmpleadosById(id);

            if (empleadoByID == null)
            {
                return NotFound();
            }
            return empleadoByID;
        }



      

        [HttpPost]
        [ActionName(nameof(CreateEmpleadosAsync))]
        public async Task<ActionResult<Empleados>> CreateEmpleadosAsync(Empleados empleados)
        {
            await _empleadoRepository.CreateEmpleadoAsync(empleados);
            return CreatedAtAction(nameof(GetEmpleadosById), new { id = empleados.id }, empleados);
        }

        [HttpPost("updateEmpleado/{id}")]
        [ActionName(nameof(UpdateEmpleados))]
        public async Task<ActionResult> UpdateEmpleados(string id, Empleados empleados)
        {
            var _id = Int32.Parse(id);
            if (_id != empleados.id)
            {
                return BadRequest();
            }

            await _empleadoRepository.UpdateEmpleadosAsync(empleados);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEmpleados))]
        public async Task<IActionResult> DeleteEmpleados(string id)
        {
            var product = _empleadoRepository.GetEmpleadosById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _empleadoRepository.DeleteEmpleadoAsync(product);

            return NoContent();
        }


        [HttpGet("FindByIdSucursal/{idSucursal}")]
        //[Route("search")]
        [ActionName(nameof(GetEmpleadosByIdSucursalAsync))]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleadosByIdSucursalAsync(string idSucursal)
        {
            var listEmpleados = await _empleadoRepository.GetEmpleadosByIdSucursal(idSucursal);

            if (listEmpleados.Any())
            {
                return Ok(listEmpleados);
            }
            return NotFound();
        }


    }
}
