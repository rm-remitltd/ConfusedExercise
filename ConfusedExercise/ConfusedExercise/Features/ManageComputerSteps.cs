using ConfusedExercise.Actors;
using ConfusedExercise.SystemUnderTest.Pages;
using TechTalk.SpecFlow;

namespace ConfusedExercise.Features
{
    [Binding]
    internal class ManageComputerSteps : Steps
    {
        private readonly BrowserActor Ryan;

        public ManageComputerSteps(BrowserActor browserActor)
        {
            Ryan = browserActor;
        }

        [Given(@"I've navigated to the computers page")]
        public void GivenIVeNavigatedToTheComputersPage()
        {
            var computersPage = Ryan.BrowsesTo<ComputersPage>();
        }

    }
}
