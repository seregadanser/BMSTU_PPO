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
using DB_course.Models.CompositModels;

namespace DB_course.Tests
{
    public class WarehouseAdminModelTests
    {
        [Fact]
        public void AddPlace_ValidPlace_AddsPlaceToUnitOfWork()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var place = new Place { Id = 1, NumberStay = 2, NumberLayer = 3, Size = 4 };
            var mockPersonRepository = new Mock<IRepository<Place>>();
            unitOfWorkMock.Setup(u => u.PlaceRepository).Returns(mockPersonRepository.Object);
            var model = new WarehouseAdminModel(unitOfWorkMock.Object);
            // Act
            model.AddPlace(place);

            // Assert
            unitOfWorkMock.Verify(x => x.PlaceRepository.Create(place), Times.Once);
            unitOfWorkMock.Verify(x => x.PlaceRepository.Save(), Times.Once);
        }

        [Fact]
        public void RemovePlace_InvalidId_ThrowsException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var model = new WarehouseAdminModel(unitOfWorkMock.Object);
            var invalidId = 0;

            // Act + Assert
            Assert.Throws<Exception>(() => model.RemovePlace(invalidId));
            unitOfWorkMock.Verify(x => x.PlaceRepository.Delete(It.IsAny<string>()), Times.Never);
            unitOfWorkMock.Verify(x => x.PlaceRepository.Save(), Times.Never);
        }

        [Fact]
        public void RemovePlace_ValidId_DeletesPlaceFromUnitOfWork()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
          
            var validId = 1;
            var mockPersonRepository = new Mock<IRepository<Place>>();
            unitOfWorkMock.Setup(u => u.PlaceRepository).Returns(mockPersonRepository.Object);
            var model = new WarehouseAdminModel(unitOfWorkMock.Object);
            // Act
            model.RemovePlace(validId);

            // Assert
            unitOfWorkMock.Verify(x => x.PlaceRepository.Delete(validId.ToString()), Times.Once);
            unitOfWorkMock.Verify(x => x.PlaceRepository.Save(), Times.Once);
        }

        [Fact]
        public void UpdatePlace_InvalidId_ThrowsException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var model = new WarehouseAdminModel(unitOfWorkMock.Object);
            var invalidId = 0;
            var newPlace = new Place { Id = 1, NumberStay = 2, NumberLayer = 3, Size = 4 };

            // Act + Assert
            Assert.Throws<Exception>(() => model.UpdatePlace(invalidId, newPlace));
            unitOfWorkMock.Verify(x => x.PlaceRepository.Update(It.IsAny<Place>()), Times.Never);
            unitOfWorkMock.Verify(x => x.PlaceRepository.Save(), Times.Never);
        }

        [Fact]
        public void UpdatePlace_PlaceDoesNotExist_ThrowsException()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var model = new WarehouseAdminModel(unitOfWorkMock.Object);
            var nonExistentId = 1;
            var newPlace = new Place { Id = 1, NumberStay = 2, NumberLayer = 3, Size = 4 };
            unitOfWorkMock.Setup(x => x.PlaceRepository.Get(nonExistentId.ToString())).Returns(Enumerable.Empty<Place>());

            // Act + Assert
            Assert.Throws<Exception>(() => model.UpdatePlace(nonExistentId, newPlace));
            unitOfWorkMock.Verify(x => x.PlaceRepository.Update(It.IsAny<Place>()), Times.Never);
            unitOfWorkMock.Verify(x => x.PlaceRepository.Save(), Times.Never);
        }


        [Fact]
        public void AddProduct_WithValidInput_ShouldCreateNewProductAndInventory()
        {
            // Arrange
            var adminCompose = new AdminCompose
            {
                DateProduction = DateTime.Today,
                DateCome = DateTime.Today,
                Name = "TestProduct",
                ProductId = 1,
                InventoryNumber = 1,
                PlaceId = "1,2,3"
            };
            var product = new Product
            {
                Id = 1,
                Name = "TestProduct",
                Value = 1
            };
            var inventoryProduct = new InventoryProduct
            {
                InventoryNumber = 1,
                ProductId = 1
            };
            var placeOfObject1 = new PlaceofObject
            {
                Id = 1,
                PlaceId = 1,
                InventoryId = 1
            };
            var placeOfObject2 = new PlaceofObject
            {
                Id = 2,
                PlaceId = 2,
                InventoryId = 1
            };
            var placeOfObject3 = new PlaceofObject
            {
                Id = 3,
                PlaceId = 3,
                InventoryId = 1
            };
            Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
     
            var mockPersonRepository = new Mock<IRepository<InventoryProduct>>();
            _unitOfWorkMock.Setup(u => u.InventoryProductRepository).Returns(mockPersonRepository.Object);


            _unitOfWorkMock.Setup(x => x.ProductRepository.Get("1")).Returns(new List<Product>());
            _unitOfWorkMock.Setup(x => x.PlaceofObjectRepository.GetList()).Returns(new List<PlaceofObject> { placeOfObject1, placeOfObject2, placeOfObject3 });

            WarehouseAdminModel _warehouseAdminModel = new WarehouseAdminModel(_unitOfWorkMock.Object);
            // Act
            _warehouseAdminModel.AddProduct(adminCompose);

            // Assert
            _unitOfWorkMock.Verify(x => x.ProductRepository.Create(It.IsAny<Product>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.InventoryProductRepository.Create(It.IsAny<InventoryProduct>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.PlaceofObjectRepository.Create(It.IsAny<PlaceofObject>()), Times.Exactly(3));
            _unitOfWorkMock.Verify(x => x.ProductRepository.Save(), Times.Once);
            _unitOfWorkMock.Verify(x => x.InventoryProductRepository.Save(), Times.Once);
            _unitOfWorkMock.Verify(x => x.PlaceofObjectRepository.Save(), Times.Exactly(3));
        }

        [Fact]
        public void RemoveProduct_ProductFoundAndHasValueGreaterThanOne_DecreasesValue()
        {
            // Arrange
            var adminCompose = new AdminCompose
            {
                InventoryNumber = 1,
                ProductId = 1,
                PlaceId = "1,2,3"
            };

            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                Value = 2,
                DateCome = DateTime.Now,
                DateProduction = DateTime.Now
            };
            Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

            var mockPersonRepository = new Mock<IRepository<InventoryProduct>>();
            _unitOfWorkMock.Setup(u => u.InventoryProductRepository).Returns(mockPersonRepository.Object);
            var mockPersonRepository1 = new Mock<IRepository<PlaceofObject>>();
            _unitOfWorkMock.Setup(u => u.PlaceofObjectRepository).Returns(mockPersonRepository1.Object);




            WarehouseAdminModel _warehouseAdminModel = new WarehouseAdminModel(_unitOfWorkMock.Object);

            _unitOfWorkMock.Setup(x => x.ProductRepository.Get("1")).Returns(() => new List<Product> { product });

            // Act
            _warehouseAdminModel.RemoveProduct(adminCompose);

            // Assert
            _unitOfWorkMock.Verify(x => x.PlaceofObjectRepository.Delete("1"), Times.Once);
            _unitOfWorkMock.Verify(x => x.PlaceofObjectRepository.Delete("2"), Times.Once);
            _unitOfWorkMock.Verify(x => x.PlaceofObjectRepository.Delete("3"), Times.Once);
            _unitOfWorkMock.Verify(x => x.PlaceofObjectRepository.Save(), Times.Exactly(3));
            _unitOfWorkMock.Verify(x => x.InventoryProductRepository.Delete("1"), Times.Once);
            _unitOfWorkMock.Verify(x => x.InventoryProductRepository.Save(), Times.Once);
            _unitOfWorkMock.Verify(x => x.ProductRepository.Delete(It.IsAny<string>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.ProductRepository.Update(product), Times.Once);
            _unitOfWorkMock.Verify(x => x.ProductRepository.Save(), Times.Once);
        }
    }
    }
