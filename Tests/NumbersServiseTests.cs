using NUnit.Framework;
using Domain;
using Data;
using Data.Models;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace NumbersApp.Tests
{
    [TestFixture]
    [Category("UnitTests")]
    public class NumbersServiseTests
    {
        private INumbersService _service;
        private Mock<IRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IRepository>();
            _service = new NumbersService(_repository.Object);
        }

        [Test]
        public async Task GetNumber_ReturnsNumberObject()
        {

            // Arrange
            var number = new Number() { Id = 1, Value = 100 };
            _repository.Setup(x => x.Create(It.IsAny<Number>())).ReturnsAsync(number);

            // Act 
            var result = await _service.GetNumber();

            //Assert
            Assert.AreEqual(100, result.Value);
        }

        [Test]
        public async Task GetallNumbers_ReturnsNumberObjects()
        {

            // Arrange
            var numbers = new List<Number>() { new Number { Id = 1, Value = 100 } };
            _repository.Setup(x => x.GetAll()).ReturnsAsync(numbers);

            // Act 
            var result = await _service.GetAllNumbers();

            // Assert
            Assert.AreEqual(100, result.First().Value);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task Delete_IsCalledCorrectly()
        {

            // Arrange
            var numbers = new List<Number>() { new Number { Id = 1, Value = 100 } };

            // Act 
            await _service.Clear();

            // Assert
            _repository.Verify(x => x.DeleteAll(), Times.Once);
        }
    }
}