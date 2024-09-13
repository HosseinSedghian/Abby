using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    /// <summary>
    /// The Category class represents a category of items in the application.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order of the category.
        /// </summary>
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
