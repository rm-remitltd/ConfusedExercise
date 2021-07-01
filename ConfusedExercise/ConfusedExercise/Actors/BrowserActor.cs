using ConfusedExercise.Selenium;
using ConfusedExercise.SystemUnderTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ConfusedExercise.Actors
{
    internal class BrowserActor : IDisposable
    {
        protected readonly IWebDriver Driver;
        protected readonly string BaseUrl;

        public BrowserActor(TestConfiguration configuration)
        {
            BaseUrl = configuration.ComputersUrl;

            var options = new ChromeOptions();

            Driver = new ChromeDriver(options);
        }

        public void Dispose() => Driver.Dispose();

        internal TPage BrowsesTo<TPage>() where TPage : PageBase
        {
            var page = (TPage)Activator.CreateInstance(typeof(TPage), Driver, BaseUrl);

            page.Navigate();

            return page;
        }
    }
}
