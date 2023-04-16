using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using DB_course.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;
using DB_course.Repositories.DBRepository;
using DB_course.Models.CompositModels;

namespace DB_course.Tests
{
    public class UnLoginTestsI
    {
        [Fact]
        public void LoginFirst()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            UnLoginModel m = new UnLoginModel(a);
            // Act
            State ac = m.Check("as", "ji");
            // Assert
            Assert.Equal(State.FIRST, ac);
        }
        [Fact]
        public void LoginUnsucces()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            UnLoginModel m = new UnLoginModel(a);
            // Act
            State ac = m.Check("as", "134");
            // Assert
            Assert.Equal(State.INVALID, ac);
        }
        [Fact]
        public void LoginNotFound()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            UnLoginModel m = new UnLoginModel(a);
            // Act
            Action act = () => m.Check("vass", "134");
            // Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Person not found", exception.Message);
        }
    }




    }
