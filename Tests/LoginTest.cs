using System;
using demo.framework;
using demo.framework.Forms;
using demo.Framework.Forms;
using NUnit.Framework;

namespace demo.Tests
{
    class LoginTest:BaseTest
    {
        private readonly String _email = RunConfigurator.GetValue("email");
        private readonly String _password = RunConfigurator.GetValue("password");
        private readonly String _username = RunConfigurator.GetValue("username");

        [Test]
        public void RunTest()
        {
            MainForm mainForm = new MainForm();

            Log.Step(1);
            mainForm.ClickLoginButton();

            Log.Step(2);
            LoginForm loginForm=new LoginForm();
            loginForm.Login(_email, _password);

            Log.Step(3);
            loginForm.AssertLogin(_username);
        }
    }



}
