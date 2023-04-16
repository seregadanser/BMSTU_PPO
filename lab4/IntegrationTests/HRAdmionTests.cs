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
    public class AHRAdminModelTestsI
    {
        [Fact]
        public void AddPerson_UnValidPerson_CreatesPerson()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a= new UnitOfWork(new SQLRepositoryAbstractFabric(connection));

            AHRAdminModel adminModel = new HRAdminModel(a);

            var person = new Person { Name = "John", SecondName = "Doe", Position = "Developer", DateOfBirthday = new DateTime(1985, 1, 1) };

            // Act
            Action act = () => adminModel.AddPerson(person);

            // Assert
            Assert.Throws<ValidationException>(act);


        }

        [Fact]
        public void RemovePerson_ExistingId_DeletesPerson()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));

            AHRAdminModel adminModel = new HRAdminModel(a);

            var existingId = "123";

            // Act
            adminModel.RemovePerson(existingId);

            // Assert
            IEnumerable<Person> l = adminModel.LookPerson();
            bool flag = true;
            foreach(Person ll in l)
            {
                if (ll.Login == "123")
                { flag = false; break; }

            }
            Assert.True(flag);
        }
        [Fact]
        public void UpdatePerson_ValidIdAndPerson_PersonUpdated()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer("Server=LAPTOPSERGEY;Database=warehouse;Trusted_Connection=True;TrustServerCertificate=True").Options;
            IConnection connection = new WarehouseContext(options);
            UnitOfWork a = new UnitOfWork(new SQLRepositoryAbstractFabric(connection));
            var model = new HRAdminModel(a);

            // Act
            model.UpdatePerson("aa", new Person
            {
                Login = "janedoe",
                Name = "Jane",
                SecondName = "Doe",
                Position = "Manager",
                Password = "newpassword",
                DateOfBirthday = new DateTime(1991, 1, 1)
            });

            // Assert
            Person p = model.LookPerson("aa").First();

            Assert.Equal("Jane", p.Name);
            Assert.Equal("Doe", p.SecondName);
            Assert.Equal("Manager", p.Position);
            Assert.Equal(new DateTime(1991, 1, 1), p.DateOfBirthday);
        }


    }

}
