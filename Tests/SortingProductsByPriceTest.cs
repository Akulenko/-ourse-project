using System;
using NUnit.Framework;
using demo.framework;
using demo.framework.Forms;
using Assert = NUnit.Framework.Assert;

namespace demo.Tests
{
    class SortingProductsByPriceTest:BaseTest
    {
        private readonly String _product = RunConfigurator.GetValue("product");
        private readonly String _tillPrice = RunConfigurator.GetValue("till_price");

        [Test]
        public void RunTest()
        {
            Log.Step(1);
            MainForm mainForm = new MainForm();
            mainForm.AssertLogo();

            Log.Step(2, string.Format("Go to the catalog of '{0}'!", _product));
            mainForm.ClickNavigateLink(_product);

            Log.Step(3,(string.Format("Filter items by maximum price : '{0}'!", _tillPrice)));
            CatalogPage catalog = new CatalogPage();
            catalog.Select_Till_Price_Parametr(_tillPrice);

            Log.Step(4);
            catalog.SortingItems("Дешевые");
            catalog.AssertAscOrder();

            Log.Step(5);
            catalog.SortingItems("Дорогие");
            catalog.AssertDescOrder();
        }

    }
}

