using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeApp.Models.Order
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<MenuItem> Items { get; set; }
        public decimal Price { get; set; }
        public Restaurant? restaurant { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
