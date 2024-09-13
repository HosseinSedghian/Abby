using Microsoft.AspNetCore.Identity;

namespace Abby.Models
{
    /// <summary>
    /// The ApplicationUser class represents a user in the application.
    /// It extends the IdentityUser class provided by ASP.NET Core Identity.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public List<OrderHeader> OrderHeaders { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
