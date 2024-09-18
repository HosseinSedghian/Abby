using System.ComponentModel.DataAnnotations;
namespace Abby.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        [Range(1, 100, ErrorMessage = "Please select a count between 1 and 100.")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
        public MenuItem MenuItem { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
