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
    public class AWorkerModelTestsI
    {
        [Fact]
        public void AddUseful_ValidValue_CreateUseful()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            var model = new WorkerModel(a, "as");

            var value = new WorkerLookCompose { Inventory_number = 456 };

            // Act
            model.AddUseful(value);

            // Assert
            IEnumerable<WorkerLookUsefulCompose> l=  model.LookUsing();
            Assert.Equal(1, l.Count());
        }
    }
    }
