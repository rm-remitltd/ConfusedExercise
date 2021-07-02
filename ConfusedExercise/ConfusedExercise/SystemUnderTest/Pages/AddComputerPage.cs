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

        public override void Navigate() => Driver.Navigate().GoToUrl(BaseUrl + PageUrl);
        
        public void Add(Computer computer)
        {
            SetFields(computer);

            CreateComputerButton.Click();
        }
        #endregion
    }
}
