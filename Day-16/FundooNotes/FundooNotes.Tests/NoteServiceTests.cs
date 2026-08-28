using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundooNotes.Models.DTOs;
using FundooNotes.Models.Entities;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Services;

namespace FundooNotes.Tests
{
    [TestClass]
    public class NoteServiceTests
    {
        private Mock<INoteRepository> _mockRepo = null!;
        private NoteService _noteService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<INoteRepository>();
            _noteService = new NoteService(_mockRepo.Object);
        }

        [TestMethod]
        public async Task CreateNoteAsync_ShouldReturnCreatedNote()
        {
            // Arrange
            int userId = 1;
            var dto = new CreateNoteDto { Title = "My Note", Description = "My Description" };
            var expectedNote = new NotesEntity { NoteId = 10, Title = "My Note", Description = "My Description", UserId = userId };

            _mockRepo.Setup(r => r.CreateNoteAsync(It.IsAny<NotesEntity>()))
                     .ReturnsAsync(expectedNote);

            // Act
            var result = await _noteService.CreateNoteAsync(dto, userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("My Note", result.Title);
            Assert.AreEqual(userId, result.UserId);
        }

        [TestMethod]
        public async Task GetAllNotesAsync_ShouldReturnUserNotes()
        {
            // Arrange
            int userId = 1;
            var notes = new List<NotesEntity>
            {
                new NotesEntity { NoteId = 1, Title = "Note 1", UserId = userId },
                new NotesEntity { NoteId = 2, Title = "Note 2", UserId = userId }
            };

            _mockRepo.Setup(r => r.GetAllNotesByUserIdAsync(userId))
                     .ReturnsAsync(notes);

            // Act
            var result = await _noteService.GetAllNotesAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task DeleteNoteAsync_ShouldReturnTrue_WhenDeleted()
        {
            // Arrange
            int userId = 1;
            long noteId = 5;

            _mockRepo.Setup(r => r.DeleteNoteAsync(noteId, userId))
                     .ReturnsAsync(true);

            // Act
            var result = await _noteService.DeleteNoteAsync(noteId, userId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task PinNoteAsync_ShouldReturnTrue_WhenPinned()
        {
            // Arrange
            int userId = 1;
            long noteId = 3;

            _mockRepo.Setup(r => r.PinNoteAsync(noteId, userId))
                     .ReturnsAsync(true);

            // Act
            var result = await _noteService.PinNoteAsync(noteId, userId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ArchiveNoteAsync_ShouldReturnTrue_WhenArchived()
        {
            // Arrange
            int userId = 1;
            long noteId = 3;

            _mockRepo.Setup(r => r.ArchiveNoteAsync(noteId, userId))
                     .ReturnsAsync(true);

            // Act
            var result = await _noteService.ArchiveNoteAsync(noteId, userId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task TrashNoteAsync_ShouldReturnTrue_WhenTrashed()
        {
            // Arrange
            int userId = 1;
            long noteId = 3;

            _mockRepo.Setup(r => r.TrashNoteAsync(noteId, userId))
                     .ReturnsAsync(true);

            // Act
            var result = await _noteService.TrashNoteAsync(noteId, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
