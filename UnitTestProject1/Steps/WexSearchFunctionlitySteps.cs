using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace UnitTestProject1.Steps
{
    [Binding]
   public class WexSearchFunctionlitySteps
    {
        private IWebDriver _currentDriver = null;
        [Given(@"I navigate to '(.*)'")]
        public void GivenINavigateTo(string p0)
        {
            var chromeOptions = new ChromeOptions();
            //to execute faster, uncomment that's code
            //chromeOptions.AddArguments("--headless");
            _currentDriver = new ChromeDriver(chromeOptions);

            _currentDriver.Url = p0;
            _currentDriver.Manage().Window.Maximize();
        }

        [Given(@"I write the sentence '(.*)'")]
        public void GivenIWriteTheSentence(string p0)
        {
            Thread.Sleep(000);
            _currentDriver.FindElement(By.Id("mega-menu-item-439")).Click();
            _currentDriver.FindElement(By.Id("s")).SendKeys(p0); 
            _currentDriver.FindElement(By.Id("s")).SendKeys(Keys.Enter);
        }

        [Then(@"the result should be a list of topics about health")]
        public void ThenTheResultShouldBeAListOfTopicsAboutHealth()
        {
            try
            {
                string pattern = @"Health";
                var topic = _currentDriver.FindElement(By.XPath("//*[@id=\"mainContent\"]/div[2]/div/div/div[1]/h4/a")).Text;
                var regex = new Regex(pattern);


                var exist = regex.IsMatch(topic);
                Assert.IsTrue(exist);
            }
            catch (NoSuchElementException e)
            {
                Assert.IsTrue(false,"Could not find the page!");
            }
            
        }

        [Then(@"the result should be a list of topics reduce costs")]
        public void ThenTheResultShouldBeAListOfTopicsReduceCosts()
        {
            string pattern = @"Commercial Card";
            var topic = _currentDriver.FindElement(By.XPath("//*[@id=\"mainContent\"]/div[2]/div/div/div[1]/h4/a")).Text;
            var regex = new Regex(pattern);


            var exist = regex.IsMatch(topic);
            Assert.IsTrue(exist);
        }


        [AfterScenario]
        public void AfterScenario()
        { 
            _currentDriver.Quit();
            _currentDriver.Dispose();
        }



    }
}
