using ConfusedExercise.Selenium;
using ConfusedExercise.SystemUnderTest.Models;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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
        private IWebElement NextPageLink => Driver.FindElement(By.CssSelector("#pagination li.next"));
        private IWebElement ComputersFoundTitle => Driver.FindElement(By.CssSelector("#main h1"));

        #endregion

        #region Public methods

        public AddComputerPage Add()
        {
            AddNewButton.Click();

            return new AddComputerPage(Driver, BaseUrl);
        }

        public EditComputerPage Edit(Computer computer)
        {
            var computerTableRow = FindTableRow(computer.Name);

            if (computerTableRow == null)
                throw new Exception($"Couldn't find computer '{computer.Name}' in the list.");

            computerTableRow.FindElement(By.TagName("a")).Click();

            return new EditComputerPage(Driver, BaseUrl);
        }

        public void FilterBy(string text)
        {
            SearchBox.SendKeys(text);

            SearchSubmit.Click();
        }

        public void NextPage() => NextPageLink.FindElement(By.TagName("a")).Click();

        public bool IsDisplaying(Computer computer) => FindTableRow(computer.Name) != null;

        #endregion

        #region Public properties

        public bool EndOfList => NextPageLink.GetAttribute("class").Contains("disabled");

        public int NumberOfComputersFound => ParseComputersFoundTitle(ComputersFoundTitle.Text);

        #endregion

        #region Private methods

        private IWebElement FindTableRow(string computerName)
        {
            do
            {
                var matchingRows = Driver.FindElements(By.XPath($@"//a[contains(text(),""{computerName}"")]/../.."));

                if (matchingRows.Any()) return matchingRows.First();

                NextPage();

            } while (!EndOfList);

            return null;
        }

        private int ParseComputersFoundTitle(string titleText)
        {
            var match = Regex.Match(titleText, @"(\d*|one|no) computer(?:s|) found", RegexOptions.IgnoreCase);

            if (!match.Success) return 0;

            switch (match.Groups[1].Value.ToLower())
            {
                case "one": return 1;
                case "no": return 0;
                default:
                    int.TryParse(match.Groups[1].Value, out var computersFound);
                    return computersFound;
            }
        }

        #endregion

    }
}
