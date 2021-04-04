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

            UIBehavior.PressButton("��� ������", driver);
            UIBehavior.ClickFindElement("a","���������� ���������", driver);
            UIBehavior.PressButton("��� �����", driver);
            UIBehavior.SelectCheckBox("����������", true, driver);
            Assert.AreEqual(5,UIBehavior.GetCountFindElementsCssSelector("a.card-no-hover:not(.bg-info)", driver));
        }

        // ���������� ������� �������� ����� ��������� �����.
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}