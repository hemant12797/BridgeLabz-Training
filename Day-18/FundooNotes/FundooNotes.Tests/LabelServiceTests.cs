using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundooNotes.Models.DTOs;
using FundooNotes.Models.Entities;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Services;

namespace FundooNotes.Tests
{
    [TestClass]
    public class LabelServiceTests
    {
        private Mock<ILabelRepository> _mockRepo = null!;
        private LabelService _labelService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<ILabelRepository>();
            _labelService = new LabelService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task AddLabelAsync_ShouldReturnCreatedLabel()
        {
            // Arrange
            int userId = 1;
            var dto = new CreateLabelDto { LabelName = "Work", NoteId = 10 };
            var expectedLabel = new LabelEntity { LabelId = 1, LabelName = "Work", NoteId = 10, UserId = userId };

            _mockRepo.Setup(r => r.AddLabelAsync(It.IsAny<LabelEntity>()))
                     .ReturnsAsync(expectedLabel);

            // Act
            var result = await _labelService.AddLabelAsync(dto, userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Work", result.LabelName);
            Assert.AreEqual(userId, result.UserId);
        }

        [TestMethod]
        public async Task GetLabelByIdAsync_ShouldReturnLabel_WhenExists()
        {
            // Arrange
            int userId = 1;
            int labelId = 5;
            var expectedLabel = new LabelEntity { LabelId = labelId, LabelName = "Personal", UserId = userId };

            _mockRepo.Setup(r => r.GetLabelByIdAsync(labelId, userId))
                     .ReturnsAsync(expectedLabel);

            // Act
            var result = await _labelService.GetLabelByIdAsync(labelId, userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(labelId, result.LabelId);
            Assert.AreEqual("Personal", result.LabelName);
        }

        [TestMethod]
        public async Task EditLabelAsync_ShouldReturnUpdatedLabel()
        {
            // Arrange
            int userId = 1;
            int labelId = 2;
            var dto = new UpdateLabelDto { LabelName = "Updated Label" };
            var updatedLabel = new LabelEntity { LabelId = labelId, LabelName = "Updated Label", UserId = userId };

            _mockRepo.Setup(r => r.EditLabelAsync(labelId, dto.LabelName, userId))
                     .ReturnsAsync(updatedLabel);

            // Act
            var result = await _labelService.EditLabelAsync(labelId, dto, userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Label", result.LabelName);
        }

        [TestMethod]
        public async Task GetAllLabelsAsync_ShouldReturnAllUserLabels()
        {
            // Arrange
            int userId = 1;
            var labels = new List<LabelEntity>
            {
                new LabelEntity { LabelId = 1, LabelName = "Home", UserId = userId },
                new LabelEntity { LabelId = 2, LabelName = "Office", UserId = userId }
            };

            _mockRepo.Setup(r => r.GetAllLabelsAsync(userId))
                     .ReturnsAsync(labels);

            // Act
            var result = await _labelService.GetAllLabelsAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task DeleteLabelAsync_ShouldReturnTrue_WhenDeleted()
        {
            // Arrange
            int userId = 1;
            int labelId = 3;

            _mockRepo.Setup(r => r.DeleteLabelAsync(labelId, userId))
                     .ReturnsAsync(true);

            // Act
            var result = await _labelService.DeleteLabelAsync(labelId, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
