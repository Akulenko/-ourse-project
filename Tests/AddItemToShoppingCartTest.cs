using demo.framework;
using demo.framework.Forms;
using demo.Framework.Forms;
using NUnit.Framework;

namespace demo.Tests
{
    class AddItemToShoppingCartTest:BaseTest
    {
        private string nameProductFromCatalog;
        private string nameProductFromCart;

        [Test]
        public void RunTest()
        {
            MainForm mailForm = new MainForm();

            Log.Step(1);
            mailForm.ClickCatalogMenu();
            CatalogPage catalog = new CatalogPage();

            Log.Step(2);
            catalog.Select_Catalog_Product();
            nameProductFromCatalog = catalog.GetNameProduct();

            Log.Step(3);
            catalog.ShowPricesForProduct();

            Log.Step(4);
            catalog.AddProductToCart();

            Log.Step(5, "Go to the Shopping Cart");
            catalog.ClickShoppingCart();
            ShoppingCartForm ShoppingCart = new ShoppingCartForm();

            Log.Step(6,"Check that Shopping Cart has added product");
            nameProductFromCart = ShoppingCart.GetNameProduct();
            Assert.AreEqual(nameProductFromCart,nameProductFromCatalog);
        }
    }
}
