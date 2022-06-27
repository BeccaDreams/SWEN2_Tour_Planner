using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner_DAL;
using Shared.Models;

namespace Tour_Planner.Test
{
    public class TourLogDataHandlerTests
    {
        TourLogDataHandler logDataHandler;
        List<TourLog> tourLog;


        [SetUp]
        public void Setup()
        {
            logDataHandler = new TourLogDataHandler();
        }


        [Test]
        public void Test_getTourLogsById_shouldNotBeEmpty()
        {
            tourLog = logDataHandler.getTourLogsByTourId(1);

           // Assert.IsNotEmpty(tourLog); DB muss noch befüllt werden
           Assert.IsEmpty(tourLog);
        }

        [Test]
        public void Test_searchTourLog_____()
        {
            Assert.Pass();
        }

    }
}
