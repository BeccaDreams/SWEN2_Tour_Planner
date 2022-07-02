using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_DAL;
using Shared.Models;
using Moq;
using Npgsql;
using System.Reflection;

namespace Tour_Planner.Test
{
    public class TourDataHandlerTests
    {
        TourDataHandler tourDataHandler;
        Mock<Database> mockDatabase;
        Mock<TourSqlCommands> mockSqlCommands;

        [SetUp]
        public void Setup()
        {
            //https://stackoverflow.com/questions/2050892/how-to-mock-a-static-singleton
            var unused = Database.Instance();
            System.Reflection.FieldInfo instance = typeof(Database).GetField("instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            mockDatabase = new Mock<Database>();
            instance.SetValue(null, mockDatabase.Object);

            mockSqlCommands = new Mock<TourSqlCommands>();
            tourDataHandler = new TourDataHandler();
        }

        [Test]
        public void Test_getTours_shouldCallDbExecuteReader()
        {
            //Arrange
            mockDatabase.Setup(db => db.executeReader(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<NpgsqlDataReader>());

            //Act
            tourDataHandler.getTours();

            //Assert
            mockDatabase.Verify(db => db.executeReader(It.IsAny<NpgsqlCommand>()), Times.Once);
        }

        [Test]
        public void Test_getTourById_shouldCallDbExecuteReader()
        {
            //Arrange
            mockDatabase.Setup(db => db.executeReader(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<NpgsqlDataReader>());

            //Act
            tourDataHandler.getTourById(It.IsAny<int>());

            //Assert
            mockDatabase.Verify(db => db.executeReader(It.IsAny<NpgsqlCommand>()), Times.Once);
        }  
        
        [Test]
        public void Test_searchTours_shouldCallDbExecuteReader()
        {
            //Arrange
            //mockSqlCommands.Setup(cmd => cmd.searchTour(It.IsAny<String>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeReader(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<NpgsqlDataReader>());

            //Act
            tourDataHandler.searchTour("test");

            //Assert
            mockDatabase.Verify(db => db.executeReader(It.IsAny<NpgsqlCommand>()), Times.Once);
        }

        [Test]
        public void Test_addTour_shouldCallDbExecuteNoneQuery()
        {
            //Arrange
            mockSqlCommands.Setup(cmd => cmd.addTour(It.IsAny<Tour>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<bool>());

            //Act
            tourDataHandler.addTour(new Tour());

            //Assert
            mockDatabase.Verify(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>()), Times.Once);
        }  
        
        [Test]
        public void Test_updateTour_shouldCallDbExecuteNoneQuery()
        {
            //Arrange
            mockSqlCommands.Setup(cmd => cmd.updateTour(It.IsAny<Tour>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<bool>());

            //Act
            tourDataHandler.updateTour(new Tour());

            //Assert
            mockDatabase.Verify(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>()), Times.Once);
        }
        
        [Test]
        public void Test_deleteTour_shouldCallDbExecuteNoneQuery()
        {
            //Arrange
            mockSqlCommands.Setup(cmd => cmd.deleteTour(It.IsAny<Tour>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<bool>());

            //Act
            tourDataHandler.deleteTour(new Tour());

            //Assert
            mockDatabase.Verify(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>()), Times.Once);
        }


    }
}
