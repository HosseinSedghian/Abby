using Abby.Models;
using Xunit;

namespace Abby.Test
{
    public class ModelsTests
    {
        [Fact]
        public void ApplicationUser_ShouldHaveFirstNameAndLastName()
        {
            // Arrange
            var user = new ApplicationUser
            {
                FirstName = "John",
                LastName = "Doe"
            };

            // Act & Assert
            Assert.Equal("John", user.FirstName);
            Assert.Equal("Doe", user.LastName);
        }

        [Fact]
        public void Category_ShouldHaveNameAndDisplayOrder()
        {
            // Arrange
            var category = new Category
            {
                Name = "Beverages",
                DisplayOrder = 1
            };

            // Act & Assert
            Assert.Equal("Beverages", category.Name);
            Assert.Equal(1, category.DisplayOrder);
        }

        [Fact]
        public void FoodType_ShouldHaveName()
        {
            // Arrange
            var foodType = new FoodType
            {
                Name = "Vegetarian"
            };

            // Act & Assert
            Assert.Equal("Vegetarian", foodType.Name);
        }

        [Fact]
        public void MenuItem_ShouldHaveProperties()
        {
            // Arrange
            var menuItem = new MenuItem
            {
                Name = "Pizza",
                Description = "Delicious cheese pizza",
                ImageUrl = "http://example.com/pizza.jpg",
                Price = 9.99,
                CategoryId = 1,
                FoodTypeId = 2
            };

            // Act & Assert
            Assert.Equal("Pizza", menuItem.Name);
            Assert.Equal("Delicious cheese pizza", menuItem.Description);
            Assert.Equal("http://example.com/pizza.jpg", menuItem.ImageUrl);
            Assert.Equal(9.99, menuItem.Price);
            Assert.Equal(1, menuItem.CategoryId);
            Assert.Equal(2, menuItem.FoodTypeId);
        }
    }
}
