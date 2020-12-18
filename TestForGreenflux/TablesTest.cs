using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace TableTests
{
    public class Test
    {
        private IWebDriver driver;

        [Test()]

        //test for Table1
        public void TestCaseEditAndDelete1()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");

            var rowsCount = driver.FindElements(By.CssSelector("#table1 > tbody > tr")).Count;
            Assert.Greater(rowsCount, 0, "The table is empty");

            IList<IWebElement> EditCollection = driver.FindElements(By.CssSelector("#table1 a[href^='#edit']"));
            Assert.AreEqual(rowsCount, EditCollection.Count, "Some rows don't have Edit button");

            //check that every Edit button is clickable
            foreach (IWebElement element in EditCollection)
            {
                element.Click();
            }

            IList<IWebElement> DeleteCollection = driver.FindElements(By.CssSelector("#table1 a[href^='#delete']"));
            Assert.AreEqual(rowsCount, DeleteCollection.Count, "Some rows don't have Delete button");

            //check that every Delete button is clickable
            foreach (IWebElement element in DeleteCollection)
            {
                element.Click();
            }

            driver.Quit();
        }

        [Test()]

        //test for Table2
        public void TestCaseEditAndDelete2()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");

            var rowsCount = driver.FindElements(By.CssSelector("#table2 > tbody > tr")).Count;
            Assert.Greater(rowsCount, 0, "The table is empty");

            IList<IWebElement> EditCollection = driver.FindElements(By.CssSelector("#table2 a[href^='#edit']"));
            Assert.AreEqual(rowsCount, EditCollection.Count, "Some rows don't have Edit button");

            //check that every Edit button is clickable
            foreach (IWebElement element in EditCollection)
            {
                element.Click();
            }

            IList<IWebElement> DeleteCollection = driver.FindElements(By.CssSelector("#table2 a[href^='#delete']"));
            Assert.AreEqual(rowsCount, DeleteCollection.Count, "Some rows don't have Delete button");

            //check that every Delete button is clickable
            foreach (IWebElement element in DeleteCollection)
            {
                element.Click();
            }

            driver.Quit();
        }
    }
}
