using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using DB_course.Models;
using Xunit;
using Moq;
using DB_course.Repositories.DBRepository;
using DB_course.Models.CompositModels;

namespace DB_course.Tests
{
    public class UnLoginTests
    {
        [Fact]
        public void LoginFirst()
        {
            // Arrange
            List<Person> a = new List<Person>();
            a.Add(new Person() { Password = "1234", Login = "vas", NumberOfCome = 0 });
            var ui = new Mock<IUnitOfWork>();
            ui.Setup(a => a.personRepository.Get(It.IsAny<string>())).Returns(a);
            UnLoginModel m = new UnLoginModel(ui.Object);
            // Act
            State ac = m.Check("vas", "1234");
            // Assert
            Assert.Equal(State.FIRST, ac);
        }
        [Fact]
        public void LoginUnsucces()
        {
            // Arrange
            List<Person> a = new List<Person>();
            a.Add(new Person() { Password = "1234", Login = "vas", NumberOfCome = 0 });
            var ui = new Mock<IUnitOfWork>();
            ui.Setup(a => a.personRepository.Get(It.IsAny<string>())).Returns(a);
            UnLoginModel m = new UnLoginModel(ui.Object);
            // Act
            State ac = m.Check("vas", "134");
            // Assert
            Assert.Equal(State.INVALID, ac);
        }
        [Fact]
        public void LoginNotFound()
        {
            // Arrange
            var ui = new Mock<IUnitOfWork>();
            ui.Setup(a => a.personRepository.Get(It.IsAny<string>())).Returns(new List<Person>());
            UnLoginModel m = new UnLoginModel(ui.Object);
            // Act
            Action act = () => m.Check("vas", "134");
            // Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Person not found", exception.Message);
        }
    }




    }
