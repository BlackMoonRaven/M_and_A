namespace M_and_A.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}