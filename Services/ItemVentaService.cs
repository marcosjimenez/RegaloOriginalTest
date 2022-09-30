using Microsoft.EntityFrameworkCore;
using RegaloOriginalTest.Domain.Models;
using RegaloOriginalTest.Infrastructure;
using RegaloOriginalTest.ViewModels;

namespace RegaloOriginalTest.Services
{
    public class ItemVentaService : IItemVentaService
    {

        private readonly RODbContext _context;
        public ItemVentaService(RODbContext context)
        {
            _context = context;
        }

        public async Task<List<ItemVentaViewModel>> GetItemsVenta(int ventaId)
        {
            var items = await _context.ItemsVenta
            .Where(x => x.VentaId == ventaId)
            .ToListAsync();

            return items.ToViewModel();
        }

        public async Task<ItemVentaViewModel> GetItemVenta(int ventaId, int itemVentaId)
        {
            var itemVenta = await _context.ItemsVenta.SingleOrDefaultAsync(x => x.VentaId == ventaId && x.Id == itemVentaId);
            if (itemVenta is null)
            {
                throw new KeyNotFoundException(nameof(itemVentaId));
            }

            return new ItemVentaViewModel
            {
                Id = itemVentaId,
                Precio = itemVenta.Precio
            };
        }

        public async Task AddItemVentaAsync(int ventaId, int productoId, double precio)
        {
            await ThrowIfVentaNotExists(ventaId);

            var producto = await _context.Productos.SingleOrDefaultAsync(x => x.Id == productoId);
            if (producto is null)
            {
                throw new KeyNotFoundException(nameof(productoId));
            }

            var itemVenta = new ItemVenta
            {
                VentaId = ventaId,
                Producto = producto,
                Precio = precio
            };

            await _context.ItemsVenta.AddAsync(itemVenta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemVentaAsync(int ventaId, int itemVentaId, int productoId, double precio)
        {

            await ThrowIfVentaNotExists(ventaId);

            var itemVenta = await _context.ItemsVenta.SingleOrDefaultAsync(x => x.VentaId == ventaId && x.Id == itemVentaId);
            if (itemVenta is null)
                throw new KeyNotFoundException(nameof(productoId));

            if (itemVenta.Producto.Id != productoId)
            {
                var newProducto = await _context.Productos.SingleOrDefaultAsync(x => x.Id == productoId);
                if (newProducto is null)
                {
                    throw new KeyNotFoundException(nameof(productoId));
                }

                itemVenta.Producto = newProducto;
            }

            itemVenta.Precio = precio;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteItemVenta(int ventaId, int itemVentaId)
        {
            await ThrowIfVentaNotExists(ventaId);

            var itemVenta = await _context.ItemsVenta.SingleOrDefaultAsync(x => x.Id == itemVentaId);
            if (itemVenta is null)
            {
                throw new KeyNotFoundException(nameof(itemVentaId));
            }

            _context.ItemsVenta.Remove(itemVenta);
            await _context.SaveChangesAsync();
        }


        private async Task ThrowIfVentaNotExists(int ventaId)
        {
            if (!await _context.Ventas.AnyAsync(x => x.Id == ventaId))
            {
                throw new KeyNotFoundException(nameof(ventaId));
            }
        }

    }
}
