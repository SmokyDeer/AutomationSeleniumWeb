using OpenQA.Selenium;

namespace QAAutomationSeleniumWeb
{
    static class UIBehavior
    {

        /// <summary>
        /// Метод моделирует клик по кнопке с указаным текстом
        /// </summary>
        /// <param name="textButton">Текст кнопки</param>
        /// <param name="driver">IWebDriver браузер</param>
        static public void PressButton(string textButton, IWebDriver driver)
        {
            By button = By.XPath(string.Format("//button[text()='{0}']", textButton));
            IWebElement buttonFind = driver.FindElement(button);
            buttonFind.Click();
        }

        /// <summary>
        /// Метод устанавливает необходимое значение CheckBox 
        /// </summary>
        /// <param name="textLable">Текст lable</param>
        /// <param name="setCheckFlag">Значение флага, которое нужно установить</param>
        /// <param name="driver">IWebDriver браузер</param>
        static public void SelectCheckBox(string textLable, bool setCheckFlag, IWebDriver driver)
        {
            By button = By.XPath(string.Format("//label[text()='{0}']", textLable));
            IWebElement lableFind = driver.FindElement(button);
            string idInput = lableFind.GetAttribute("for");
            IWebElement idInputFind = driver.FindElement(By.Id(idInput));
            if (idInputFind.GetAttribute("checked") != null)
            {
                CheckBox(true, setCheckFlag);
            }
            else
            {
                CheckBox(false, setCheckFlag);
            }


            ///Если флаг установлен в неудовлетворяющем нас положении, то производится изменение состояния флага
            void CheckBox(bool check, bool setCheckFlag)
            {
                if (check != setCheckFlag)
                {
                    lableFind.Click();
                }
            }


        }

        /// <summary>
        /// Метод моделирует клик по найденному элементу
        /// </summary>
        /// <param name="findAttribute">Искомый аттрибут</param>
        /// <param name="textAttribute">Текст аттрибута</param>
        /// <param name="driver">IWebDriver браузер</param>
        static public void ClickFindElement(string findAttribute,string textAttribute, IWebDriver driver)
        {
            By element = By.XPath(string.Format("//{0}[text()='{1}']", findAttribute, textAttribute));
            IWebElement findElement = driver.FindElement(element);
            findElement.Click();
        }

        /// <summary>
        /// Метод определяет кол-во найденных элементов по css селекторам
        /// </summary>
        /// <param name="cssSelector">CSS селектор</param>
        /// <param name="driver">IWebDriver браузер</param>
        /// <returns>Возвращает кол-во найденных элементов</returns>
        static public int GetCountFindElementsCssSelector(string cssSelector, IWebDriver driver)
        {
            return driver.FindElements(By.CssSelector(cssSelector)).Count;
        }
    }
}
