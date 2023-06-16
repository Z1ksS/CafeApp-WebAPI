using CafeApp.Models;
using CafeApp.Models.Order;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeApp
{
    public class User : IdentityRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Score { get; set; } = new Random().Next(10, 300);
        public Roles Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
