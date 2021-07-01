using OpenQA.Selenium;

namespace ConfusedExercise.Selenium
{
    internal abstract class PageBase
    {
        protected readonly IWebDriver Driver;
        protected readonly string BaseUrl;
        protected readonly string PageUrl;

        public PageBase(IWebDriver driver, string baseUrl, string pageUrl) 
            => (Driver, BaseUrl, PageUrl) = (driver, baseUrl, pageUrl);

        public abstract void Navigate();
    }
}
