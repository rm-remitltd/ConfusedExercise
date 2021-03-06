using ConfusedExercise.Actors;
using ConfusedExercise.Specflow;
using ConfusedExercise.SystemUnderTest.Models;
using ConfusedExercise.SystemUnderTest.Pages;
using ConfusedExercise.SystemUnderTest.TestData;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace ConfusedExercise.Features
{
    [Binding]
    internal class ManageComputerSteps : StepsBase
    {
        private readonly BrowserActor Ryan;

        public ManageComputerSteps(BrowserActor browserActor) => Ryan = browserActor;

        #region Givens

        [Given(@"the user adds a new computer")]
        public void GivenTheUserAddsANewComputer()
        {
            var newComputer = Computers.UniqueComputer;

            Ryan.BrowsesTo<AddComputerPage>().Add(newComputer);

            Save(newComputer);
        }

        [Given(@"the user selects a computer")]
        public void GivenTheUserSelectsAComputer()
        {
            GivenTheUserAddsANewComputer();

            var computer = Retrieve<Computer>();

            var editPage = Ryan.BrowsesTo<ComputersPage>().Edit(computer);

            Save(editPage);
        }

        #endregion

        #region Whens

        [When(@"they view the list of computers in the system")]
        public void WhenTheyViewTheListOfComputersInTheSystem()
        {
            var computersPage = Ryan.BrowsesTo<ComputersPage>();

            Save(computersPage);
        }

        [When(@"they delete the selected computer")]
        public void WhenTheyDeleteTheSelectedComputer()
        {
            Retrieve<EditComputerPage>().DeleteComputer();
        }

        [When(@"the user uses the filter to search for a computer that exists in the system")]
        public void WhenTheUserUsesTheFilterToSearchForAComputerThatExistsInTheSystem()
        {
            GivenTheUserAddsANewComputer();

            var computer = Retrieve<Computer>();

            var computersPage = Ryan.BrowsesTo<ComputersPage>();
            computersPage.FilterBy(computer.Name);

            Save(computersPage);
        }

        [When(@"the user uses the filter to search for a computer that doesn't exist in the system")]
        public void WhenTheUserUsesTheFilterToSearchForAComputerThatDoesnTExistInTheSystem()
        {
            var computersPage = Ryan.BrowsesTo<ComputersPage>();
            computersPage.FilterBy(Guid.NewGuid().ToString());

            Save(computersPage);
        }

        #endregion

        #region Thens

        [Then(@"the new computer will be shown")]
        public void ThenTheNewComputerWillBeShown()
        {
            var (newComputer, computersPage) = Retrieve<Computer, ComputersPage>();

            Ryan.ObservesThat(computersPage, cp => cp.IsDisplaying(newComputer)).Should().BeTrue(
                because: "the computer was added to the database.");
        }

        [Then(@"the computer will no longer show in the list")]
        public void ThenTheComputerWillNoLongerShowInTheList()
        {
            var deletedComputer = Retrieve<Computer>();

            var computersPage = Ryan.BrowsesTo<ComputersPage>();

            Ryan.ObservesThat(computersPage, cp => cp.IsDisplaying(deletedComputer)).Should().BeFalse(
                because: "the user deleted the computer");
        }

        [Then(@"the computer will be displayed in the list of filtered results")]
        public void ThenTheComputerWillBeDisplayedInTheListOfFilteredResults()
        {
            var (computersPage, expectedComputer) = Retrieve<ComputersPage, Computer>();

            Ryan.ObservesThat(computersPage, cp => cp.NumberOfComputersFound).Should().BeGreaterThan(0,
                because: "the filter used should've returned some results");

            Ryan.ObservesThat(computersPage, cp => cp.IsDisplaying(expectedComputer)).Should().BeTrue(
                because: $"the user filtered on computers called '{expectedComputer.Name}'");
        }

        [Then(@"no results will be displayed")]
        public void ThenNoResultsWillBeDisplayed()
        {
            var computersPage = Retrieve<ComputersPage>();

            Ryan.ObservesThat(computersPage, cp => cp.NumberOfComputersFound).Should().Be(0,
                because: "the user filtered on a computer that doesn't exist");
        }

        #endregion
    }
}
