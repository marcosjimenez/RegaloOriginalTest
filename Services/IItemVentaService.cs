using RegaloOriginalTest.Domain.Models;
using RegaloOriginalTest.ViewModels;

namespace RegaloOriginalTest.Services
{
    public interface IItemVentaService
    {
        Task<List<ItemVentaViewModel>> GetItemsVenta(int ventaId);
        Task<ItemVentaViewModel> GetItemVenta(int ventaId, int itemVentaId);
        Task AddItemVentaAsync(int ventaId, int productoId, double precio);
        Task UpdateItemVentaAsync(int ventaId, int itemVentaId, int productoId, double precio);
        Task DeleteItemVenta(int ventaId, int itemVentaId);
    }
}