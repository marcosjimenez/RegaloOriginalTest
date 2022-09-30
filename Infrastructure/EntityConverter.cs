using RegaloOriginalTest.Domain.Models;
using RegaloOriginalTest.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace RegaloOriginalTest.Infrastructure
{
    public static class EntityConverter
    {

        public static ProductoViewModel ToViewModel(this Producto producto)
            => new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre
            };

        public static List<ProductoViewModel> ToViewModel(this List<Producto> productos)
        {
            var retVal = new List<ProductoViewModel>();

            foreach(var item in productos)
            {
                retVal.Add(item.ToViewModel());
            }

            return retVal;
        }

        public static ItemVentaViewModel ToViewModel(this ItemVenta item)
            => new ItemVentaViewModel
            {
                Id = item.Id,
                Precio= item.Precio,
                Producto = item.Producto?.ToViewModel()
            };

        public static List<ItemVentaViewModel> ToViewModel(this List<ItemVenta> items)
        {
            var retVal = new List<ItemVentaViewModel>();

            foreach (var item in items)
            {
                retVal.Add(item.ToViewModel());
            }

            return retVal;
        }

    }
}
