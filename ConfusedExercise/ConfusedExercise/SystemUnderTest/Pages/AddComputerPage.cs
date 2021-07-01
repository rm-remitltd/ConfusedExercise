using ConfusedExercise.SystemUnderTest.Models;
using OpenQA.Selenium;

namespace ConfusedExercise.SystemUnderTest.Pages
{
    internal class AddComputerPage : ComputerPageBase
    {
        public AddComputerPage(IWebDriver driver, string baseUrl)
            : base(driver, baseUrl, "/new") { }

        #region Elements

        private IWebElement CreateComputerButton => Driver.FindElement(By.CssSelector("input[type=submit]"));

        #endregion

        #region Public methods

        public void Add(Computer computer)
        {
            ComputerName = computer.Name;
            IntroducedDate = computer.IntroducedDate;
            DiscontinuedDate = computer.DiscontinuedDate;
            ComputerName = computer.Company;

            CreateComputerButton.Click();
        }
        #endregion
    }
}
