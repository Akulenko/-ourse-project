using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework;
using demo.framework.Elements;
using demo.framework.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demo.Framework.Forms
{
    class WeatherForm:BaseForm
    {
        private readonly Link _selectCityLink = new Link(By.CssSelector(".js-weather-city"), "open list of cities");
        private readonly By _weatherCityListBy = By.CssSelector(".js-weather-city-list.js-visible");
        private readonly Link _selectedCityBy = new Link(By.CssSelector(".js-weather-city-list .selected"));
        public WeatherForm() : base(By.XPath("//*"), "pogoda.onliner.by"){}

        public void OpenWeatherCityList()
        {
            _selectCityLink.Click();
            Browser.getWhenVisible(_weatherCityListBy);
        }

        public void SelectCity(string weatherCity)
        {
            IWebElement listCity = Browser.GetDriver().FindElement(_weatherCityListBy);
            IWebElement cityElement =listCity.FindElement(By.LinkText(weatherCity));
            cityElement.Click();
            Browser.WaitForPageToLoad();
        }

        public void AssertCity(string weatherCity)
        {
            _selectCityLink.Click();
            Assert.AreEqual(weatherCity,_selectedCityBy.IsSelected());
        }

    }
}
