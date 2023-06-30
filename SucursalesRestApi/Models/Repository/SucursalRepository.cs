using Microsoft.EntityFrameworkCore;

namespace SucursalesRestApi.Models.Repository
{
    public class SucursalRepository : ISucursaleRepository
    {
        protected readonly Context _context;
        public SucursalRepository(Context context) => _context = context;

        public async Task<Sucursales> CreateSucursalAsync(Sucursales sucursal)
        {
            await _context.Set<Sucursales>().AddAsync(sucursal);
            await _context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<bool> DeleteSucursalesAsync(Sucursales sucursal)
        {
            if (sucursal is null) {
                return false;
            }
            _context.Set<Sucursales>().Remove(sucursal);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Sucursales> GetSucursales()
        {
            return _context.Sucursales.ToList();
        }

        public Sucursales GetSucursalesById(int id)
        {
            var sucursal = _context.Sucursales.Find(id);
            if (sucursal is null)
            {
                throw new Exception("No se encontro sucursal");
            }
            return sucursal;
        }

        public async Task<bool> UpdateSucursalessAsync(Sucursales sucursal)
        {
            _context.Entry(sucursal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
