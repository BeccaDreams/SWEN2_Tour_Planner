using NUnit.Framework;
using Shared.Models;
using System;
using Tour_Planner_BL;

namespace Tour_Planner.Test
{
    public class MapQuestClientTest
    {
        MapQuestClient mapQuestClient;

        [SetUp]
        public void Setup() 
        {
            mapQuestClient = new MapQuestClient();
        }

        [Test]
        public void Test_GetMapQuestStaticMap_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => mapQuestClient.GetMapQuestStaticMap(null));
        }

        [Test]
        public void Test_GetMapQuestStaticMap_ShouldCallApiWithParameters()
        {
            //Arrange
            var direction = new MapQuestDirectionResponse();
            direction.Route = new Route();
            direction.Route.SessionId = "6zt67kij";
            direction.Route.BoundingBox = new BoundingBox();
            direction.Route.BoundingBox.Lr = new Coordinat { Lat = 34, Lng = 44 };
            direction.Route.BoundingBox.Ul = new Coordinat { Lat = 54, Lng = 64 };
            
            var url = "http://www.mapquestapi.com/staticmap/v5/map?key=u3H8AC3EFF0GLWj6o0U8E4wD6NMLdp2L&boundingBox=54,64,34,44&session=6zt67kij";

            //Act
            var res = mapQuestClient.getMapUrl(direction);

            //Assert
            Assert.AreEqual(url, res);
        }
        
        [Test]
        public void Test_GetMapQuestDirection_ShouldThrowArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => mapQuestClient.GetMapQuestDirection(String.Empty, "to", "type"));
        }   
    }
}
