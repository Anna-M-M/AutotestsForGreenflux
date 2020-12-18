using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DynamicControlTests
{
    [TestFixture()]
    public class Test

    {
        private IWebDriver driver;
        private const int delay = 5000;

        [Test()]

        //test with selected checkbox and without input data
        public void TestCaseSelectedCheckbox()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");

            driver.FindElement(By.CssSelector("#checkbox input")).Click();

            driver.FindElement(By.CssSelector("#checkbox-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsFalse(CheckPresenceCheckBox(), "Check-box wasn't deleted");

            driver.FindElement(By.CssSelector("#checkbox-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsTrue(CheckPresenceCheckBox(), "Check-box wasn't added");


            driver.FindElement(By.CssSelector("#input-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsTrue(CheckInputEnabled(), "Input is not enabled");

            driver.FindElement(By.CssSelector("#input-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsFalse(CheckInputEnabled(), "Input is not disabled");

            driver.Quit();
        }

        [Test()]

        //test with input data and without selected checkbox
        public void TestCaseInputData()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");

            driver.FindElement(By.CssSelector("#checkbox-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsFalse(CheckPresenceCheckBox(), "Check-box wasn't deleted");

            driver.FindElement(By.CssSelector("#checkbox-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsTrue(CheckPresenceCheckBox(), "Check-box wasn't added");


            driver.FindElement(By.CssSelector("#input-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsTrue(CheckInputEnabled(), "Input is not enabled");

            driver.FindElement(By.CssSelector("#input-example input")).SendKeys("abcdef/?");

            driver.FindElement(By.CssSelector("#input-example button")).Click();
            System.Threading.Thread.Sleep(delay);
            Assert.IsFalse(CheckInputEnabled(), "Input is not disabled");

            driver.Quit();
        }


        public bool CheckPresenceCheckBox()
        {
            try
            {
                driver.FindElement(By.Id("checkbox"));
                return true;
            }

            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public bool CheckInputEnabled()
        {
            return driver.FindElement(By.CssSelector("#input-example input")).Enabled;
            
        }
        
    }
}
