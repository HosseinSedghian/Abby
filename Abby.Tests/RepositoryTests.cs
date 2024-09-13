using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Abby.Test
{
    public class RepositoryTests
    {
        private readonly Mock<AppDbContext> _mockContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;

        public RepositoryTests()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _categoryRepository = new CategoryRepository(_mockContext.Object);
            _foodTypeRepository = new FoodTypeRepository(_mockContext.Object);
        }

        [Fact]
        public void AddCategory_ShouldAddCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", DisplayOrder = 1 };

            // Act
            _categoryRepository.Add(category);
            _categoryRepository.Save();

            // Assert
            _mockContext.Verify(m => m.Categories.Add(It.IsAny<Category>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void UpdateCategory_ShouldUpdateCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", DisplayOrder = 1 };

            // Act
            _categoryRepository.Update(category);
            _categoryRepository.Save();

            // Assert
            _mockContext.Verify(m => m.Categories.Update(It.IsAny<Category>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void AddFoodType_ShouldAddFoodType()
        {
            // Arrange
            var foodType = new FoodType { Id = 1, Name = "Test FoodType" };

            // Act
            _foodTypeRepository.Add(foodType);
            _foodTypeRepository.Save();

            // Assert
            _mockContext.Verify(m => m.FoodTypes.Add(It.IsAny<FoodType>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void UpdateFoodType_ShouldUpdateFoodType()
        {
            // Arrange
            var foodType = new FoodType { Id = 1, Name = "Test FoodType" };

            // Act
            _foodTypeRepository.Update(foodType);
            _foodTypeRepository.Save();

            // Assert
            _mockContext.Verify(m => m.FoodTypes.Update(It.IsAny<FoodType>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
