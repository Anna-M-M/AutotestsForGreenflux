using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AuthorizationTests
{
    [TestFixture()]
    public class Test   

    {
        private IWebDriver driver;
        private const string _logincorrect = "tomsmith";
        private const string _loginincorrect = "wronglogin";
        private const string _passwordcorrect = "SuperSecretPassword!";
        private const string _passwordincorrect = "12345";

        [Test()]

        //positive test with correct login and password
        public void TestCaseCorrectLoginandPassword()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys(_logincorrect);
            driver.FindElement(By.Id("password")).SendKeys(_passwordcorrect);
            driver.FindElement(By.ClassName("radius")).Click();

            var _actualResult = driver.FindElement(By.Id("flash")).Text;
            var _expectedResult = "You logged into a secure area!";

            Assert.IsTrue(_actualResult.Contains(_expectedResult));

            driver.Quit();
        }

        [Test()]

        //negative test with correct login and incorrect password
        public void TestCaseIncorrectPassword()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys(_logincorrect);
            driver.FindElement(By.Id("password")).SendKeys(_passwordincorrect);
            driver.FindElement(By.ClassName("radius")).Click();

            var _actualResult = driver.FindElement(By.Id("flash")).Text;
            var _expectedResult = "Your password is invalid!";

            Assert.IsTrue(_actualResult.Contains(_expectedResult));

            driver.Quit();
        }

        [Test()]

        //negative test with incorrect login and correct password
        public void TestCaseIncorrectLogin()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys(_loginincorrect);
            driver.FindElement(By.Id("password")).SendKeys(_passwordcorrect);
            driver.FindElement(By.ClassName("radius")).Click();

            var _actualResult = driver.FindElement(By.Id("flash")).Text;
            var _expectedResult = "Your username is invalid!";

            Assert.IsTrue(_actualResult.Contains(_expectedResult));

            driver.Quit();
        }

        [Test()]

        //negative test with incorrect login and incorrect password
        public void TestCaseIncorrectLoginandPassword()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys(_loginincorrect);
            driver.FindElement(By.Id("password")).SendKeys(_passwordincorrect);
            driver.FindElement(By.ClassName("radius")).Click();

            var _actualResult = driver.FindElement(By.Id("flash")).Text;
            var _expectedResult = "Your username is invalid!";

            Assert.IsTrue(_actualResult.Contains(_expectedResult));

            driver.Quit();
        }

        [Test()]

        //negative test with correct login and empty password
        public void TestCaseCorrectLoginandEmptyPassword()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys(_logincorrect);
            driver.FindElement(By.ClassName("radius")).Click();

            var _actualResult = driver.FindElement(By.Id("flash")).Text;
            var _expectedResult = "Your password is invalid!";

            Assert.IsTrue(_actualResult.Contains(_expectedResult));

            driver.Quit();
        }
    }
}
