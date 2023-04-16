using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DB_course.Models.CompositModels;
using Microsoft.EntityFrameworkCore;

namespace DB_course.Tests
{
    public class WarehouseAdminModelTestsI
    {
        [Fact]
        public void AddPlace_ValidPlace_AddsPlaceToUnitOfWork()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));

            var place = new Place { Id = 98, NumberStay = 2, NumberLayer = 9, Size = 4 };

            var model = new WarehouseAdminModel(a);
            // Act
            model.AddPlace(place);

            // Assert

            Place p = model.GetPlace(Convert.ToString(98)).First();

            Assert.NotNull(p);

        }

        [Fact]
        public void RemovePlace_InvalidId_ThrowsException()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            var model = new WarehouseAdminModel(a);
            var invalidId = 0;

            // Act + Assert
            Assert.Throws<IdException>(() => model.RemovePlace(invalidId));

        }

        [Fact]
        public void RemovePlace_ValidId_DeletesPlaceFromUnitOfWork()
        {
            // Arrange
          
            var validId = 98;
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            var model = new WarehouseAdminModel(a);
            // Act
            model.RemovePlace(validId);

            // Assert
            IEnumerable<Place> l = model.GetPlace();
            bool flag = true;
            foreach (Place ll in l)
            {
                if (ll.Id == 98)
                { flag = false; break; }

            }
            Assert.True(flag);

        }

        [Fact]
        public void UpdatePlace_InvalidId_ThrowsException()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            var model = new WarehouseAdminModel(a);
            var invalidId = 0;
            var newPlace = new Place { Id = 1, NumberStay = 2, NumberLayer = 3, Size = 4 };

            // Act + Assert
            Assert.Throws<IdException>(() => model.UpdatePlace(invalidId, newPlace));
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
                ProductId = 4,
                InventoryNumber = 89,
                PlaceId = "1,2,3"
            };
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));

            WarehouseAdminModel _warehouseAdminModel = new WarehouseAdminModel(a);
            // Act
            _warehouseAdminModel.AddProduct(adminCompose);

            // Assert
            IEnumerable<AdminCompose> l = _warehouseAdminModel.GetProducts();
            bool flag = true;
            foreach (AdminCompose ll in l)
            {
                if (ll.Name == "TestProduct")
                {
                    if (ll.value != 1)
                    { flag = false; break; }
                }
                Assert.True(flag);
            }
        }

        [Fact]
        public void RemoveProduct_ProductFoundAndHasValueGreaterThanOne_DecreasesValue()
        {
            // Arrange
            var adminCompose = new AdminCompose
            {
                InventoryNumber = 23,
                ProductId = 2,
                PlaceId = "1",
                PlaceOfObjectlId = "1"
            };


            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));


            WarehouseAdminModel _warehouseAdminModel = new WarehouseAdminModel(a);

            // Act
            _warehouseAdminModel.RemoveProduct(adminCompose);

            // Assert
            IEnumerable<AdminCompose> l = _warehouseAdminModel.GetProducts();
            bool flag = true;
            foreach (AdminCompose ll in l)
            {
                if (ll.ProductId == 2)
                {
                    if (ll.value != 1)
                    { flag = false; break; }
                }
                Assert.True(flag);
            }
        }
    }
    }
