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

namespace demo.Framework.Forms
{
    class LoginForm:BaseForm
    {
        private readonly TextBox _usernameTextBox=new TextBox(By.XPath("//input[contains(@data-bind,'root.login.data.login')]"),"Fill in the username");
        private readonly TextBox _passwordTextBox = new TextBox(By.XPath("//input[contains(@data-bind,'root.login.data.password')]"), "Fill in the password");
        private readonly Button _submitButton=new Button(By.XPath("//button[contains(.,'Войти')]"),"'Войти' button");
        private readonly By _loginFormBy = By.CssSelector(".auth-box__inner--form");
        private readonly Link _currentUserNameLink = new Link(By.XPath("//a[contains(@data-bind,'currentUser.nickname')]"), "logged users");
        public LoginForm() : base(By.XPath("//*"), "Login form") {}

        public void Login(string username, string password)
        {
            Browser.getWhenVisible(_loginFormBy);
            _usernameTextBox.SetText(username);
            _passwordTextBox.SetText(password);
            _submitButton.Click();
        }

        public void AssertLogin(string userName)
        {
            Assert.AreEqual(_currentUserNameLink.IsPresent(), true);
            Assert.AreEqual(userName, _currentUserNameLink.IsSelected());

        }
    }
}
