using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abby.Models
{
    /// <summary>
    /// The MenuItem class represents a menu item in the application.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the menu item.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the menu item.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the menu item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the image URL of the menu item.
        /// </summary>
        [Required]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the price of the menu item.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Price should be between $1 and $1000.")]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the category ID of the menu item.
        /// </summary>
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category of the menu item.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the food type ID of the menu item.
        /// </summary>
        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        /// <summary>
        /// Gets or sets the food type of the menu item.
        /// </summary>
        [ForeignKey(nameof(FoodTypeId))]
        public FoodType FoodType { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
