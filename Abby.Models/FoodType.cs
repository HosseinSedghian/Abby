using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    /// <summary>
    /// The FoodType class represents a type of food in the application.
    /// </summary>
    public class FoodType
    {
        /// <summary>
        /// Gets or sets the unique identifier for the food type.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the food type.
        /// </summary>
        [Required]
        public string Name { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
