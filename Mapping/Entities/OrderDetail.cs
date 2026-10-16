namespace Mapping.Entities
{
    internal class OrderDetail
    {

        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public Order Order { get; set; } = null!;// order detail is associated with an order
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!; // order detail is associated with a product
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}