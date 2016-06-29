using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace demo.framework.Forms
{
    public class MainForm:BaseForm
    {
        private Link lbLogo = new Link(By.CssSelector(".onliner_logo"), "onliner.by logo");
        private Link catalog = new Link(By.XPath("//span[contains(.,'Каталог')]"), "go to Catalog");
        private Link weatherLink=new Link(By.XPath("//a[@class='b-top-navigation-informers__link'][contains(@href, 'pogoda')]"),"open weather menu");
        private Link loginLink = new Link(By.CssSelector(".auth-bar__item--text"), "login button");
        private string navigateLink="//span[@class='project-navigation__sign']";
 
        public MainForm() : base(By.XPath("//*"), "onliner.by") {}
        
        public void AssertLogo()
        {
            Assert.AreEqual(lbLogo.IsPresent(), true);
        }

        public void ClickCatalogMenu()
        {
            catalog.Click();
            Browser.WaitForPageToLoad();

        }

        public void ClickNavigateLink(string nameLink)
        {
            By navigateNameLinkBy = By.XPath(navigateLink + "[contains(.,'" + nameLink + "')]");
            Browser.GetDriver().FindElement(navigateNameLinkBy).Click();
        }

        
        
        public void ClickWeatherMenu()
        {
            weatherLink.Click();
            Browser.WaitForPageToLoad();
        }

        public void ClickLoginButton()
        {
            loginLink.Click();
            Browser.WaitForPageToLoad();
        }

        


    }
}
