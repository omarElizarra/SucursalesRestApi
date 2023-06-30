using SucursalesRestApi.Models;

namespace SucursalesRestApi.Models.Repository
{
    public interface IEmpleadoRepository
    {

        Task<Empleados> CreateEmpleadoAsync(Empleados empleado);
        Task<bool> DeleteEmpleadoAsync(Empleados empleado);
        Task<IEnumerable<Empleados>> GetEmpleadosByIdSucursal(string id);
        Empleados GetEmpleadosById(string id);
        IEnumerable<Empleados> GetEmpleados();
        Task<bool> UpdateEmpleadosAsync(Empleados empleado);
    }
}
