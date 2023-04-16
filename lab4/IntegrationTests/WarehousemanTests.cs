using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DB_course.Tests
{
    public class AWarehousemanModelTestsI
    {

        [Fact]
        public void DelitUseful_InvalidId_ThrowsException()
        {
            // Arrange
            int invalidId = -1;
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            WarehousemanModel m = new WarehousemanModel(a);
            // Act & Assert
            Assert.Throws<IdException>(() => m.DelitUseful(invalidId));
        }

        [Fact]
        public void DelitUseful_ValidId_CallsDeleteAndSave()
        {
            // Arrange
            int validId = 1;
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            WarehousemanModel m = new WarehousemanModel(a);

            // Act
            m.DelitUseful(validId);

            // Assert
  
        }

    }
}
