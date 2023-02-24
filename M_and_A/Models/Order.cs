namespace M_and_A.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
