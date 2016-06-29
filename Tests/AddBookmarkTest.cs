using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework;
using demo.framework.Forms;
using demo.Framework.Forms;
using NUnit.Framework;

namespace demo.Tests
{
    class AddBookmarkTest:BaseTest
    {

        private readonly String _email = RunConfigurator.GetValue("email");
        private readonly String _password = RunConfigurator.GetValue("password");

        private string nameProductFromCatalog;

        [Test]
        public void RunTest()
        {

            MainForm mainForm = new MainForm();

            Log.Step(1);
            mainForm.ClickCatalogMenu();
            CatalogPage catalog = new CatalogPage();

            Log.Step(2);
            catalog.Select_Catalog_Product();
            nameProductFromCatalog = catalog.GetNameProduct();

            Log.Step(3);
            catalog.ShowPricesForProduct();

            Log.Step(4);
            catalog.AddBookmark();

            Log.Step(5);
            LoginForm loginForm = new LoginForm();
            loginForm.Login(_email, _password);

            Log.Step(6);
            ProfileForm profile=new ProfileForm();
            profile.OpenBookmakers("Каталог");
            profile.AssertName(nameProductFromCatalog);

            Log.Step(7);
            profile.RemoveAllBookmakers();
            profile.AssertName(nameProductFromCatalog);

        }
    }
}
