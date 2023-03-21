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
    public class AWarehousemanModelTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private AWarehousemanModel _warehousemanModel;

        public AWarehousemanModelTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _warehousemanModel = new WarehousemanModel(_mockUnitOfWork.Object);
        }

        [Fact]
        public void DelitUseful_InvalidId_ThrowsException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            Assert.Throws<Exception>(() => _warehousemanModel.DelitUseful(invalidId));
        }

        [Fact]
        public void DelitUseful_ValidId_CallsDeleteAndSave()
        {
            // Arrange
            int validId = 1;
            var mockUsefulRepository = new Mock<IRepository<Useful>>();
            _mockUnitOfWork.Setup(u => u.UsefulRepository).Returns(mockUsefulRepository.Object);

            // Act
            _warehousemanModel.DelitUseful(validId);

            // Assert
            mockUsefulRepository.Verify(r => r.Delete(validId.ToString()), Times.Once);
            mockUsefulRepository.Verify(r => r.Save(), Times.Once);
        }
        [Fact]
        public void LookWarehousemanLook_ReturnsListOfWarehousemanLookComposeFromUnitOfWork()
        {
            // Arrange
            var warehousemanLookComposeList = new List<WarehousemanLookCompose>()
        {
            new WarehousemanLookCompose(),
            new WarehousemanLookCompose(),
            new WarehousemanLookCompose()
        };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.WarehousemanLookComposeRepository.GetList())
                .Returns(warehousemanLookComposeList);
            _warehousemanModel = new WarehousemanModel(unitOfWorkMock.Object);

            // Act
            var result = _warehousemanModel.LookWarehousemanLook();

            // Assert
            Assert.Equal(warehousemanLookComposeList, result);
        }

        [Fact]
        public void LookWarehousemanLook_WithSearchValue_ReturnsFilteredListOfWarehousemanLookComposeFromUnitOfWork()
        {
            // Arrange
            var searchValue = "test";

            var warehousemanLookComposeList = new List<WarehousemanLookCompose>()
        {
            new WarehousemanLookCompose() { Name = "Test 1" },
            new WarehousemanLookCompose() { Name = "Test 2" },
            new WarehousemanLookCompose() { Name = "Other" }
        };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.WarehousemanLookComposeRepository.Get(searchValue))
                .Returns(warehousemanLookComposeList.Where(wlc => wlc.Name.Contains(searchValue)));
            _warehousemanModel = new WarehousemanModel(unitOfWorkMock.Object);


            // Act
            var result = _warehousemanModel.LookWarehousemanLook(searchValue);

            // Assert
            Assert.Equal(warehousemanLookComposeList.Where(wlc => wlc.Name.Contains(searchValue)), result);
        }
    }
}
