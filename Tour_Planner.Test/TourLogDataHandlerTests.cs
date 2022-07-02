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

namespace Tour_Planner.Test
{
    public class TourLogDataHandlerTests
    {
        TourLogDataHandler logDataHandler;
        Mock<Database> mockDatabase;
        Mock<TourLogSqlCommands> mockSqlCommands;


        [SetUp]
        public void Setup()
        {
            //https://stackoverflow.com/questions/2050892/how-to-mock-a-static-singleton
            var unused = Database.Instance();
            System.Reflection.FieldInfo instance = typeof(Database).GetField("instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            mockDatabase = new Mock<Database>();
            instance.SetValue(null, mockDatabase.Object);

            mockSqlCommands = new Mock<TourLogSqlCommands>();
            logDataHandler = new TourLogDataHandler();
        }


        [Test]
        public void Test_getTourLogsById_shouldCallDbExecuteReader()
        {
            //Arrange
            mockDatabase.Setup(db => db.executeReader(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<NpgsqlDataReader>());

            //Act
            logDataHandler.getTourLogsByTourId(1);

            //Assert
            mockDatabase.Verify(db => db.executeReader(It.IsAny<NpgsqlCommand>()), Times.Once);
        }

        [Test]
        public void Test_searchTourLog_shouldCallDbExecuteReader()
        {
            //Arrange
            mockDatabase.Setup(db => db.executeReader(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<NpgsqlDataReader>());

            //Act
            logDataHandler.searchTourLog("test");

            //Assert
            mockDatabase.Verify(db => db.executeReader(It.IsAny<NpgsqlCommand>()), Times.Once);
        }

        [Test]
        public void Test_addTourLog_shouldCallDbExecuteNoneQuery()
        {
            //Arrange
            mockSqlCommands.Setup(cmd => cmd.addTourLog(It.IsAny<int>(),It.IsAny<TourLog>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<bool>());

            //Act
            logDataHandler.addTourLog(1, new TourLog());

            //Assert
            mockDatabase.Verify(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>()), Times.Once);
        }  
        
        [Test]
        public void Test_updateTourLog_shouldCallDbExecuteNoneQuery()
        {
            //Arrange
            mockSqlCommands.Setup(cmd => cmd.updateTourLog(It.IsAny<TourLog>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<bool>());

            //Act
            logDataHandler.updateTourLog(new TourLog());

            //Assert
            mockDatabase.Verify(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>()), Times.Once);
        }        
        
        [Test]
        public void Test_deleteTourLog_shouldCallDbExecuteNoneQuery()
        {
            //Arrange
            mockSqlCommands.Setup(cmd => cmd.deleteTourLog(It.IsAny<TourLog>())).Returns(It.IsAny<NpgsqlCommand>());
            mockDatabase.Setup(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>())).Returns(It.IsAny<bool>());

            //Act
            logDataHandler.deleteTourLog(new TourLog());

            //Assert
            mockDatabase.Verify(db => db.executeNonQuery(It.IsAny<NpgsqlCommand>()), Times.Once);
        }

    }
}
