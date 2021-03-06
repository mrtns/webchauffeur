﻿using System;
using OpenQA.Selenium;

namespace WebChauffeur
{
    public class JavaScriptSelector : BaseSelector
    {
        public JavaScriptSelector(string selectorString) : base(selectorString) {}

        public override IWebElement Select(IWebDriver driver) {
            var javascriptExecutingDriver = (IJavaScriptExecutor) driver;
            string javascriptToExecute = String.Format("return {0};", Selector);
            return javascriptExecutingDriver.ExecuteScript(javascriptToExecute) as IWebElement;
        }
    }
}