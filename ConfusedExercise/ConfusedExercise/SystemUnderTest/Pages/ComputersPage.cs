using ConfusedExercise.Selenium;
using OpenQA.Selenium;

namespace ConfusedExercise.SystemUnderTest.Pages
{
    internal class ComputersPage : PageBase
    {
        public ComputersPage(IWebDriver driver, string baseUrl) 
            : base(driver, baseUrl, string.Empty) {}

        public override void Navigate() => Driver.Navigate().GoToUrl(BaseUrl + PageUrl);

        #region Elements

        private IWebElement SearchBox => Driver.FindElement(By.Id("searchbox"));
        private IWebElement SearchSubmit => Driver.FindElement(By.Id("searchsubmit"));
        private IWebElement AddNewButton => Driver.FindElement(By.Id("add"));
        private IWebElement NextPageLink => Driver.FindElement(By.CssSelector("#pagination li.next a"));

        #endregion

        #region Public methods

        public AddComputerPage AddComputer()
        {
            AddNewButton.Click();

            return new AddComputerPage(Driver, BaseUrl);
        }

        public void Filter(string text)
        {
            SearchBox.SendKeys(text);

            SearchSubmit.Click();
        }

        public void NextPage() => NextPageLink.Click();
        #endregion

    }
}
