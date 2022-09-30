namespace RegaloOriginalTest.Domain.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
        public IEnumerable<ItemVenta> ItemsVenta { get; set; }
    }
}
