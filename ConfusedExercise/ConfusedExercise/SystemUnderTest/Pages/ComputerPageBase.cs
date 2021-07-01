using ConfusedExercise.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ConfusedExercise.SystemUnderTest.Pages
{
    internal class ComputerPageBase : PageBase
    {
        public ComputerPageBase(IWebDriver driver, string baseUrl, string pageUrl) 
            : base(driver, baseUrl, pageUrl) {}

        public override void Navigate(){}

        #region Elements

        private IWebElement ComputerNameInput => Driver.FindElement(By.Id("name"));
        private IWebElement IntroducedDateInput => Driver.FindElement(By.Id("introduced"));
        private IWebElement DiscontinuedDateInput => Driver.FindElement(By.Id("discontinued"));
        private SelectElement CompanySelect => new SelectElement(Driver.FindElement(By.Id("company")));

        #endregion

        #region Public properties

        public string ComputerName { set => ComputerNameInput.SendKeys(value); }
        public string IntroducedDate { set => IntroducedDateInput.SendKeys(value); }
        public string DiscontinuedDate { set => DiscontinuedDateInput.SendKeys(value); }
        public string Company { set => CompanySelect.SelectByText(value); }

        #endregion


    }
}
