using SucursalesRestApi.Models;

namespace SucursalesRestApi.Models.Repository
{
    public interface ISucursaleRepository
    {
        Task<Sucursales> CreateSucursalAsync(Sucursales sucursal);
        Task<bool> DeleteSucursalesAsync(Sucursales sucursal);
        Sucursales GetSucursalesById(int id);
        IEnumerable<Sucursales> GetSucursales();
        Task<bool> UpdateSucursalessAsync(Sucursales sucursal);

    }
    
}
