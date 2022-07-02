using Moq;
using NUnit.Framework;
using Shared.Models;
using System.Collections.Generic;
using Tour_Planner_BL;
using Tour_Planner_BL.Controller;
using Tour_Planner_DAL;

namespace Tour_Planner.Test
{
    public class TourControllerTest
    {
        TourController controller;
        Mock<TourDataHandler> dataHandler;
        Mock<JsonExporter> exporter;
        Mock<JsonImporter> importer;
        Mock<MapQuestClient> mapQuestClient;

        [SetUp]
        public void Setup()
        {
            controller = new TourController();
            dataHandler = new Mock<TourDataHandler>();
            exporter = new Mock<JsonExporter>();
            importer = new Mock<JsonImporter>();
            mapQuestClient = new Mock<MapQuestClient>();

            controller.Handler = dataHandler.Object;
            controller.Importer = importer.Object;
            controller.Exporter = exporter.Object;
            controller.MapQuestClient = mapQuestClient.Object;
        }

        [Test]
        public void Test_Controller_AddTour_ShouldCallApiIfIgnoreApiIsFalse()
        {
            //Arrange
            var tour = new Tour { From = "from", To = "to", TransportType = "type" };
            mapQuestClient.Setup(client => client.GetMapQuestDirection("from", "to", "type"))
                .ReturnsAsync(It.IsAny<MapQuestDirectionResponse>());
            mapQuestClient.Setup(client => client.GetMapQuestStaticMap(It.IsAny<MapQuestDirectionResponse>()))
                .ReturnsAsync(It.IsAny<string>());

            //Act
            controller.Controller_addTour(tour, false);
       
            //Assert
            mapQuestClient.Verify(client => client.GetMapQuestDirection("from", "to", "type"), Times.Once);
            mapQuestClient.Verify(client => client.GetMapQuestStaticMap(It.IsAny<MapQuestDirectionResponse>()), Times.Once);
        }
        
        [Test]
        public void Test_Controller_AddTour_ShouldNotCallApiIfIgnoreApiIsTrue()
        {
            //Arrange
            var tour = new Tour { From = "from", To = "to", TransportType = "type" };
            mapQuestClient.Setup(client => client.GetMapQuestDirection("from", "to", "type"))
                .ReturnsAsync(It.IsAny<MapQuestDirectionResponse>());
            mapQuestClient.Setup(client => client.GetMapQuestStaticMap(It.IsAny<MapQuestDirectionResponse>()))
                .ReturnsAsync(It.IsAny<string>());

            //Act
            controller.Controller_addTour(tour, true);

            //Assert
            mapQuestClient.Verify(client => client.GetMapQuestDirection("from", "to", "type"), Times.Never);
            mapQuestClient.Verify(client => client.GetMapQuestStaticMap(It.IsAny<MapQuestDirectionResponse>()), Times.Never);
        }

        [Test]
        public void Test_Controller_AddTour_ShouldCallHandlerAddTour()
        {
            //Arange
            var tour = new Tour { From = "from", To = "to", TransportType = "type" };

            //Act
            controller.Controller_addTour(tour, true);

            //Assert
            dataHandler.Verify(handler => handler.addTour(tour), Times.Once);
        }

        [Test]
        public void Test_Controller_EditTour_ShouldCallHandlerUpdateTour()
        {
            //Arange
            var tour = new Tour { From = "from", To = "to", TransportType = "type" };
            mapQuestClient.Setup(client => client.GetMapQuestDirection("from", "to", "type"))
                .ReturnsAsync(new MapQuestDirectionResponse { Route = new Route()});
            mapQuestClient.Setup(client => client.GetMapQuestStaticMap(It.IsAny<MapQuestDirectionResponse>()))
                .ReturnsAsync(It.IsAny<string>());

            //Act
            controller.Controller_editTour(tour);

            //Assert
            dataHandler.Verify(handler => handler.updateTour(tour), Times.Once);
        }    
        
        [Test]
        public void Test_Controller_DeleteTour_ShouldCallHandlerDeleteTour()
        {
            //Arange
            var tour = new Tour { From = "from", To = "to", TransportType = "type" };

            //Act
            controller.Controller_deleteTour(tour);

            //Assert
            dataHandler.Verify(handler => handler.deleteTour(tour), Times.Once);
        }    
        
        [Test]
        public void Test_Controller_Export_ShouldCallExporter()
        {
            //Arrange
            List<Tour> tours = new List<Tour>();
            exporter.Setup(exp => exp.ExportTours(tours));
            dataHandler.Setup(handler => handler.getTours()).Returns(tours);

            //Act
            controller.Controller_export();

            //Assert
            exporter.Verify(exp => exp.ExportTours(tours), Times.Once);
        } 
        
        [Test]
        public void Test_Controller_Import_ShouldCallImporter()
        {
            //Arrange
            List<Tour> tours = new List<Tour>();
            tours.Add(new Tour());
            importer.Setup(imp => imp.ImportTours("import/tours.json")).Returns(tours);
            dataHandler.Setup(handler => handler.addTour(It.IsAny<Tour>())).Returns(It.IsAny<bool>());


            //Act
            controller.Controller_import();

            //Assert
            importer.Verify(imp => imp.ImportTours("import/tours.json"), Times.Once);
        }
    }
}
