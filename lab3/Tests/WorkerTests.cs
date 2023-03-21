using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DB_course.Tests
{
    public class AWorkerModelTests
    {
        [Fact]
        public void DelitUseful_ValidId_DeleteUseful()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockUsefulRepository = new Mock<IRepository<Useful>>();
            mockUnitOfWork.Setup(u => u.UsefulRepository).Returns(mockUsefulRepository.Object);
            var model = new Mock<AWorkerModel>(mockUnitOfWork.Object, "testLogin") { CallBase = true }.Object;
            var usefulId = 123;

            // Act
            model.DelitUseful(usefulId);

            // Assert
            mockUsefulRepository.Verify(r => r.Delete(usefulId.ToString()), Times.Once);
            mockUsefulRepository.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void AddUseful_ValidValue_CreateUseful()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockUsefulRepository = new Mock<IRepository<Useful>>();
            mockUnitOfWork.Setup(u => u.UsefulRepository).Returns(mockUsefulRepository.Object);
            var model = new Mock<AWorkerModel>(mockUnitOfWork.Object, "testLogin") { CallBase = true }.Object;
            var value = new WorkerLookCompose { Inventory_number = 456 };

            // Act
            model.AddUseful(value);

            // Assert
            mockUsefulRepository.Verify(r => r.Create(It.IsAny<Useful>()), Times.Once);
            mockUsefulRepository.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void UpdatePassword_ValidNewPassword_UpdatePerson()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockPersonRepository = new Mock<IRepository<Person>>();
            mockUnitOfWork.Setup(u => u.personRepository).Returns(mockPersonRepository.Object);
            var model = new Mock<AWorkerModel>(mockUnitOfWork.Object, "testLogin") { CallBase = true }.Object;
            var newPassword = "newPassword";
            var existingPerson = new Person { Name = "John", SecondName = "Doe", Position = "Developer", DateOfBirthday = new DateTime(1985, 1, 1), Login = "testLogin", Password = "oldPassword", NumberOfCome = 0 };
            mockPersonRepository.Setup(r => r.Get("testLogin")).Returns(new[] { existingPerson });

            // Act
            model.UpdatePasswoord(newPassword);

            // Assert
            mockPersonRepository.Verify(r => r.Update(existingPerson), Times.Once);
            mockPersonRepository.Verify(r => r.Save(), Times.Once);
            Assert.Equal(newPassword, existingPerson.Password);
            Assert.Equal(1, existingPerson.NumberOfCome);
        }
    }
    }
