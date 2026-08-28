using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundooNotes.Models.DTOs;
using FundooNotes.Models.Entities;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Services;

namespace FundooNotes.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepo = null!;
        private Mock<IConfiguration> _mockConfig = null!;
        private UserService _userService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockUserRepo = new Mock<IUserRepository>();
            _mockConfig = new Mock<IConfiguration>();

            _mockConfig.Setup(c => c["Jwt:Key"]).Returns("SuperSecretKeyThatIsAtLeast32BytesLongForJwtTest!");
            _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("FundooApp");
            _mockConfig.Setup(c => c["Jwt:Audience"]).Returns("FundooUsers");

            _userService = new UserService(_mockUserRepo.Object, _mockConfig.Object);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldRegisterNewUser()
        {
            // Arrange
            var registerDto = new UserRegistrationDto
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Password = "Password123"
            };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email))
                         .ReturnsAsync((User?)null);

            var createdUser = new User
            {
                UserId = 1,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email
            };

            _mockUserRepo.Setup(r => r.AddAsync(It.IsAny<User>()))
                         .ReturnsAsync(createdUser);

            // Act
            var result = await _userService.RegisterUserAsync(registerDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("jane.doe@example.com", result.Email);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldThrowException_WhenEmailExists()
        {
            // Arrange
            var registerDto = new UserRegistrationDto
            {
                Email = "existing@example.com",
                Password = "Password123"
            };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email))
                         .ReturnsAsync(new User { Email = "existing@example.com" });

            // Act & Assert
            try
            {
                await _userService.RegisterUserAsync(registerDto);
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Email is already registered.", ex.Message);
            }
        }

        [TestMethod]
        public async Task LoginUserAsync_ShouldReturnNull_WhenUserNotFound()
        {
            // Arrange
            var loginDto = new UserLoginDto
            {
                Email = "nonexistent@example.com",
                Password = "Password123"
            };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(loginDto.Email))
                         .ReturnsAsync((User?)null);

            // Act
            var result = await _userService.LoginUserAsync(loginDto);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GenerateJwtToken_ShouldReturnTokenString()
        {
            // Arrange
            var user = new User
            {
                UserId = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com"
            };

            // Act
            var token = _userService.GenerateJwtToken(user);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(token));
        }
    }
}
