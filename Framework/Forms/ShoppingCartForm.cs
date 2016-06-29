using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework;
using demo.framework.Forms;
using OpenQA.Selenium;

namespace demo.Framework.Forms
{
    class ShoppingCartForm:BaseForm
    {
        private readonly By _byNameProduct = By.XPath("//span[contains(@data-bind, 'data.product.full_name')]");

        public ShoppingCartForm() : base(By.XPath("//*"), "Shopping Cart")
        {
        }

        public string GetNameProduct()
        {
            Browser.getWhenVisible(_byNameProduct);
            IWebElement element = Browser.GetDriver().FindElement(_byNameProduct);
            string nameProduct = element.Text;
            return nameProduct;

        }




    }
}
