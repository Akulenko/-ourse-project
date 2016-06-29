using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework.Elements;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.Forms
{
    public class CatalogPage : BaseForm
    {
        private readonly By _byCatalogTitle = By.CssSelector(".schema-header__title");
        private readonly Button _offersButton = new Button(By.CssSelector(".schema-product__group:first-child .schema-product__button"), "Go to the 'Prices' page for the first item in the list products");
        private readonly Button _toCartButton =  new Button(By.CssSelector(".offers-list__button_basket"), "Add item to the Shopping Cart");
        private readonly By _shoppingCartButton = By.CssSelector(".b-top-navigation-cart__link");
        private readonly By _byNameProduct = By.CssSelector(".schema-product__group:first-child .schema-product__title");
        private readonly Link _product = new Link(By.XPath("//a[@class='catalog-bar__link catalog-bar__link_strong'][contains(.,'" + RunConfigurator.GetValue("product") + "')]"), "go to " + RunConfigurator.GetValue("product"));
        private readonly TextBox _priceTill = new TextBox(By.CssSelector("div:nth-child(2)>.schema-filter__number-input_price"), "type maximum price");
        private readonly Link _addBookmakerList=new Link(By.XPath("//span[contains(.,'Добавить в закладки')]"), "'Добавить в закладки' кнопка");
        private readonly Link _byPriceProduct = new Link(By.CssSelector(".schema-product__price-value_primary>span"),"Get all prices of searched products");
        private readonly Link _schemaOrderLink=new Link(By.CssSelector("#schema-order > a"), "Sorting items");

        private string orderLink= "//div[@class='schema-order__item']";
      
        public CatalogPage() : base(By.XPath("//*"), "catalog")
        {
        }

        public void Select_Catalog_Product()
        {
            _product.Click();
            Browser.WaitForPageToLoad();
            var catalogTitle = Browser.GetDriver().FindElement(_byCatalogTitle);
            Assert.AreEqual(catalogTitle.Text, RunConfigurator.GetValue("product"));
        }
        public string GetNameProduct()
        {
            Browser.getWhenVisible(_byNameProduct);
            IWebElement element = Browser.GetDriver().FindElement(_byNameProduct);
            string nameProduct = element.Text;
            return nameProduct;
        }

        public void Select_Till_Price_Parametr(string parametr)
        {
            _priceTill.SetText(parametr);
            Browser.WaitForPageToLoad();
        }

        public void ShowPricesForProduct()
        {
            _offersButton.Click();
            Browser.WaitForPageToLoad();
        }

        public void AddProductToCart()
        {
            _toCartButton.Click();
            Browser.WaitForPageToLoad();
        }

        public void ClickShoppingCart()
        {
            Browser.getWhenVisible(_shoppingCartButton);
            Browser.GetDriver().FindElement(_shoppingCartButton).Click();
            Browser.WaitForPageToLoad();
        }

        public void AddBookmark()
        {
            _addBookmakerList.IsPresent();
            _addBookmakerList.Click();
        }

        public void SortingItems(string orderText)
        {
            By orderNameLinkBy = By.XPath(orderLink + "[contains(.,'" + orderText + "')]");
            _schemaOrderLink.Click();
            Browser.GetDriver().FindElement(orderNameLinkBy).Click();

        }
        public void AssertAscOrder()
        {
            _byPriceProduct.AssertAscOrder();
        }

        public void AssertDescOrder()
        {
            _byPriceProduct.AssertDescOrder();
        }

    }
}
