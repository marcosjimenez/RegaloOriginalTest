namespace RegaloOriginalTest.Domain.Models
{
    public class ItemVenta
    {

        public int Id { get; set; }
        public int VentaId { get; set; }
        public double Precio { get; set; }
        public Producto Producto { get; set; }

    }
}
