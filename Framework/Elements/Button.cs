﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using demo.framework.Elements;

namespace demo.framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, String name) : base(locator, name) { }
        public Button(By locator) : base(locator) { }

    }
}
