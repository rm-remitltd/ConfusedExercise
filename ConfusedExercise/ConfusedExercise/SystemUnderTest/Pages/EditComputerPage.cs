using ConfusedExercise.SystemUnderTest.Models;
using OpenQA.Selenium;

namespace ConfusedExercise.SystemUnderTest.Pages
{
    internal class EditComputerPage : ComputerPageBase
    {
        public EditComputerPage(IWebDriver driver, string baseUrl) 
            : base(driver, baseUrl, string.Empty){}

        #region Elements

        private IWebElement SaveComputerButton 
            => Driver.FindElement(By.CssSelector(@"input[value=""Save this computer""]"));

        private IWebElement DeleteButton
            => Driver.FindElement(By.CssSelector(@"input[value=""Delete this computer""]"));

        #endregion

        #region Public methods

        public void UpdateComputer(Computer computer)
        {
            ComputerName = computer.Name;
            IntroducedDate = computer.IntroducedDate;
            DiscontinuedDate = computer.DiscontinuedDate;
            ComputerName = computer.Company;

            SaveComputerButton.Click();
        }

        public void DeleteComputer() => DeleteButton.Click();
        #endregion
    }
}
