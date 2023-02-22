using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace M_and_A.Models
{
    public class Product
    {
        public enum Category
        {
            [Display(Name = "Category not assigned")]
            Select,

            [Display(Name = "Jeans")]
            Jeans,

            [Display(Name = "Dress")]
            Dress,

            [Display(Name = "Underwear")]
            Underwear,

            [Display(Name = "Pants")]
            Pants,

            [Display(Name = "T-shirt")]
            TShirt
        }

        public int Id { get; set; }
       // [Required]
        public string? Name { get; set; }

        [Display(Name = "Category")]
        public Category Type { get; set; }
        public float Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Discount> DiscountId { get; set; }
    }
}
