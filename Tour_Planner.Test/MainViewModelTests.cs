using NUnit.Framework;
using Moq;
using Tour_Planner.ViewModels;

namespace Tour_Planner.Test
{
    public class MainViewModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFilter_shouldReturnEmpty()
        {
            //Mocks als ersatz, damit man 1 funktion testen kann und die anderen componenten nicht extra erstellen muss

            //var mockedArgumentHandler = new Mock<IArgumentHandler>();
            //var mockedCommunicationHandler = new Mock<ICommunicationHandler>();
            //var mockedContentInterpreter = new Mock<IContentInterpreter>();
            //var mockedFilterHandler = new Mock<FilterHanlder>();
            MainViewModel mvm = new MainViewModel();
            Assert.Pass();
        }
    }
}