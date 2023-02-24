using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace M_and_A.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
