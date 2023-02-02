namespace M_and_A.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrdersDatails> Details { get; set; }
        public ICollection<Products> Product { get; set; }
    }
}
