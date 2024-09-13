using Abby.DataAccess.DbInitializer;
using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Abby.Models;

namespace Abby.Test
{
    public class DbInitializerTests
    {
        private readonly Mock<AppDbContext> _mockContext;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
        private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
        private readonly Mock<ILogger<DbInitializer>> _mockLogger;
        private readonly DbInitializer _dbInitializer;

        public DbInitializerTests()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _mockUserManager = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            _mockLogger = new Mock<ILogger<DbInitializer>>();
            _dbInitializer = new DbInitializer(_mockContext.Object, _mockUserManager.Object, _mockRoleManager.Object, _mockLogger.Object);
        }

        [Fact]
        public void Initialize_ShouldApplyMigrations_WhenPendingMigrationsExist()
        {
            // Arrange
            _mockContext.Setup(c => c.Database.GetPendingMigrations()).Returns(new List<string> { "Migration1" });

            // Act
            _dbInitializer.Initialize();

            // Assert
            _mockContext.Verify(c => c.Database.Migrate(), Times.Once);
        }

        [Fact]
        public void Initialize_ShouldNotApplyMigrations_WhenNoPendingMigrationsExist()
        {
            // Arrange
            _mockContext.Setup(c => c.Database.GetPendingMigrations()).Returns(new List<string>());

            // Act
            _dbInitializer.Initialize();

            // Assert
            _mockContext.Verify(c => c.Database.Migrate(), Times.Never);
        }

        [Fact]
        public void Initialize_ShouldCreateRolesAndAdminUser_WhenRolesDoNotExist()
        {
            // Arrange
            _mockRoleManager.Setup(r => r.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            _mockUserManager.Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _mockContext.Setup(c => c.ApplicationUsers).Returns(Mock.Of<DbSet<ApplicationUser>>);

            // Act
            _dbInitializer.Initialize();

            // Assert
            _mockRoleManager.Verify(r => r.CreateAsync(It.IsAny<IdentityRole>()), Times.Exactly(4));
            _mockUserManager.Verify(u => u.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Once);
            _mockUserManager.Verify(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Initialize_ShouldNotCreateRolesAndAdminUser_WhenRolesExist()
        {
            // Arrange
            _mockRoleManager.Setup(r => r.RoleExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            // Act
            _dbInitializer.Initialize();

            // Assert
            _mockRoleManager.Verify(r => r.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);
            _mockUserManager.Verify(u => u.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
            _mockUserManager.Verify(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }
    }
}
