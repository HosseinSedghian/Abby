using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abby.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public double MenuItemPrice { get; set; }
        [Required]
        public string MenuItemName { get; set; }
        [ForeignKey(nameof(OrderId))]
        public OrderHeader OrderHeader { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public MenuItem MenuItem { get; set; }
    }
}
