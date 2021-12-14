using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected mApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(mApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}