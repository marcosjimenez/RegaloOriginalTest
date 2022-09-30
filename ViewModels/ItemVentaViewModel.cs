using RegaloOriginalTest.Domain.Models;

namespace RegaloOriginalTest.ViewModels
{
    public class ItemVentaViewModel
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public double Precio { get; set; }

        public ProductoViewModel Producto { get; set; }
    }
}
