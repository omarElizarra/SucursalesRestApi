using Microsoft.EntityFrameworkCore;
using SucursalesRestApi.Models;

namespace SucursalesRestApi.Models.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        protected readonly Context _context;

        public EmpleadoRepository(Context context) => _context = context;

        public IEnumerable<Empleados> GetEmpleados()
        {
            return _context.Empleados.ToList(); 
        }
        public async Task<Empleados> CreateEmpleadoAsync(Empleados empleado)
        {
            await _context.Set<Empleados>().AddAsync(empleado);
            await _context.SaveChangesAsync();
            return empleado;
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteEmpleadoAsync(Empleados empleado)
        {
            if (empleado is null) { 
                return false;
            }            
            _context.Set<Empleados>().Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }

        /*
        public async Task<IEnumerable<Empleados>> GetEmpleadosByIdSucursales(string id)
        {
            IQueryable<Empleados> query = _context.Empleados;

            var _id = Int32.Parse(id);
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(e => e.idSucursal.Equals(_id));
                //var empleadosList = query.ToListAsync();
            }
            return await query.ToListAsync();
            / *
            var empleado = _context.Empleados.Find(id);
            if (empleado == null) {
                throw new Exception("No se Encontro usuario! ");
            }
            return empleado;* /
            
        }*/

        public Empleados GetEmpleadosById(string _id)
        {
            IQueryable<Empleados> query = _context.Empleados;

            var id = Int32.Parse(_id);

            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                throw new Exception("No se Encontro usuario! ");
            }
            return empleado;

        }

        /*
        public Empleados GetEmpleadosByIdSucursal(string idSucursal)
        {
            //var _id = Int32.Parse(idSucursal);

            var empleado = _context.Empleados.Find(idSucursal);
            if (empleado == null)
            {
                throw new Exception("No se Encontro usuario! ");
            }
            return empleado;

        }*/

        public async Task<bool> UpdateEmpleadosAsync(Empleados empleado)
        {
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;

                //throw new Exception("No se Encontro empleado! ");
        }

        public async Task<IEnumerable<Empleados>> GetEmpleadosByIdSucursal(string id)
        {
            IQueryable<Empleados> query = _context.Empleados;

            var _id = Int32.Parse(id);
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(e => e.idSucursal.Equals(_id));
                //var empleadosList = query.ToListAsync();
            }
            return await query.ToListAsync();
        }


        /*
        public async Task<Empleados> CreateEmpleadosAsync(Empleados empleados)
        {
            await _context.Set<Empleados>().AddAsync(empleados);
            await _context.SaveChangesAsync();
            return empleados;
        }
        */
    }
}
