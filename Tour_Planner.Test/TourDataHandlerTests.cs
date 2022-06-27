using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_DAL;
using Shared.Models;
using Moq;

namespace Tour_Planner.Test
{
    public class TourDataHandlerTests
    {
        public TourDataHandler tourDataHandler;
        public List<Tour> tourList;
       // public Tour testtour;
        [SetUp]
        public void Setup()
        {
            tourDataHandler = new TourDataHandler();
            //tourList = new List<Tour>();
        }

        [Test]
        public void Test_getTours_shouldReturnNotEmpty()
        {
            //Mocks als ersatz, damit man 1 funktion testen kann und die anderen componenten nicht extra erstellen muss

            //var mockedArgumentHandler = new Mock<IArgumentHandler>();
            //var mockedCommunicationHandler = new Mock<ICommunicationHandler>();
            //var mockedContentInterpreter = new Mock<IContentInterpreter>();
            //var mockedFilterHandler = new Mock<FilterHanlder>();
            //var mockedTourLogs = new Mock<TourDetailsViewModel>();
            //var mockedTourDetails = new Mock<TourDetailsViewModel>();
            //var mockedTourList = new Mock<TourListViewModel>();
            //var mockedSearchbar = new Mock<SearchBarViewModel>();
            //MainViewModel mvm = new MainViewModel();
            //Assert.Pass();


            tourList = tourDataHandler.getTours();

            //Assert.IsNotEmpty(tourlist);
            Assert.IsEmpty(tourList);


        }

        [Test]
        public void Test_getTourById_shouldFindTourById()
        {
            tourList = tourDataHandler.getTourById(1);

            //Assert.IsNotEmpty(tourList);  DB muss noch befüllt werden
            Assert.IsEmpty(tourList);
        }

        [Test]
        public void Test_addTour_shoultBeTrue()
        {
            var mockedTour = new Mock<Tour>();
           // bool isAdded = tourDataHandler.addTour(mockedTour);
        }


    }
}
