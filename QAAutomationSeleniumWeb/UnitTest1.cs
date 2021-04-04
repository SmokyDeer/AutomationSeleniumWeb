using NUnit.Framework;
using OpenQA.Selenium;


namespace QAAutomationSeleniumWeb
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");
            driver.Manage().Window.Maximize();
        }

        
        [Test]
        public void TestMethodCountVacancies()
        {

            UIBehavior.PressButton("Все отделы", driver);
            UIBehavior.ClickFindElement("a","Разработка продуктов", driver);
            UIBehavior.PressButton("Все языки", driver);
            UIBehavior.SelectCheckBox("Английский", true, driver);
            Assert.AreEqual(5,UIBehavior.GetCountFindElementsCssSelector("a.card-no-hover:not(.bg-info)", driver));
        }

        // разрушение объекта драйвера после окончание теста.
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}