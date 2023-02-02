namespace M_and_A.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Discount> DiscountId { get; set; }
    }
}
