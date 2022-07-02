using NUnit.Framework;
using Moq;
using Tour_Planner.ViewModels;
using Tour_Planner;


namespace Tour_Planner.Test
{
    public class MainViewModelTests
    {
        public TourListViewModel mockedTourListViewModel;
        public TourDetailsViewModel mockedTourDetailsViewModel;
        public SearchBarViewModel mockedSearchBarViewModel;
        public TourLogsViewModel mockedTourLogsViewModel;
        public MainViewModel mvvm;


        [SetUp]
        public void Setup()
        {
            mockedTourListViewModel = new Mock<TourListViewModel>().Object;
            mockedTourDetailsViewModel = new Mock<TourDetailsViewModel>().Object;
            mockedSearchBarViewModel = new Mock<SearchBarViewModel>().Object;
            mockedTourLogsViewModel = new Mock<TourLogsViewModel>().Object;

            mvvm = new Mock<MainViewModel>(mockedTourListViewModel, mockedTourLogsViewModel, mockedTourDetailsViewModel, mockedSearchBarViewModel).Object;
        }

        [Test]
        public void TestFilter_shouldReturnEmpty()
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
        }

        [Test]
        public void Test_MVVM_TourItems_shouldNotBeEmptyWhenInstanciated()
        {

            //Assert.IsNotEmpty(mvvm.TourItems);

        }
    }
}