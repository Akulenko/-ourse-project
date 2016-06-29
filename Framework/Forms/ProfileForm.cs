using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using demo.framework;
using demo.framework.Elements;
using demo.framework.Forms;
using NUnit.Framework;
using OpenQA.Selenium;


namespace demo.Framework.Forms
{
    class ProfileForm:BaseForm
    {
        private readonly Link _bookmarkLink=new Link(By.XPath("//a[contains(.,'Закладки')]"), "Закладки");
        private readonly By _itemBookmakersBy = By.CssSelector(".pname a");
        private readonly By _selectAllBookmakersBy = By.CssSelector("#selectAllBookmarks");
        private readonly Button _deleteBookmakersButton=new Button(By.CssSelector(".pmchk__del"),"Delete all Bookmakers");
        
        private string bookmakerTab = "//div[@class='b-hdtopic']//a";
        public ProfileForm() : base(By.XPath("//*"), "user profile") {}

        public void OpenBookmakers(string name)
        {
            _bookmarkLink.Click();
            By nameBookmakerTaBy= By.XPath(bookmakerTab + "[contains(.,'"+name+"')]");
            Browser.GetDriver().FindElement(nameBookmakerTaBy).Click();
        }

        public void AssertName(string expected)
        {
            var elements = Browser.GetDriver().FindElements(_itemBookmakersBy).Select(o => o.Text).ToList();
            if (elements.Count > 0)
            {
                CollectionAssert.Contains(elements, expected);
                Log.Info(string.Format("Item with name: '{0}' exists!", expected));
            }
            else
            {
                Log.Info(string.Format("The list is empty!"));
            }
        }

        public void RemoveAllBookmakers()
        {
            Browser.GetDriver().FindElement(_selectAllBookmakersBy).Click();
            _deleteBookmakersButton.Click();
        }

        }


    }

