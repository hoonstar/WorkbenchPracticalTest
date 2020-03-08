using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
using System;
using System.Threading;


namespace WorkbenchPracticalTest
{
    [TestClass]
    public class TestCases
    {
        IWebDriver driver;

        [TestMethod]
        public void OpenChrome()
        {   //Testing the first case
            driver = new ChromeDriver();
            PreCondition();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            TestCase1();
            ShutDown();

            //testing the second case
            driver = new ChromeDriver();
            PreCondition();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            TestCase2();
            ShutDown();
        }

        [TestMethod]
        public void PreCondition()
        {
            if (driver != null)
            {
                //goes to website
                driver.Navigate().GoToUrl("https://web.workbench.co.nz/WorkbenchTestV4/Workbench.aspx#/PurchaseRequisitions/DetailMobi.aspx/Create");

                //enters username
                IWebElement username = driver.FindElement(By.Id("userName"));
                username.SendKeys("demo1");
                username.SendKeys(Keys.Enter);

                //enters password
                IWebElement password = driver.FindElement(By.Id("userPassword"));
                password.SendKeys("test");
                password.SendKeys(Keys.Enter);
            }


        }

        [TestMethod]
        public void TestCase1() //This test case is where the Purchase Requisition has been submitted successfully
        {
            if (driver != null)
            {
                //enters job code
                IWebElement job = driver.FindElement(By.Id("GeneralFields_Job"));
                job.SendKeys("4112");
                Thread.Sleep(500); //adding this solved the problem. The problem was that it could not register the job code.
                job.SendKeys(Keys.Enter);

                //enters description
                IWebElement desc = driver.FindElement(By.Id("GeneralFields_Description"));
                desc.SendKeys("Any");
                desc.SendKeys(Keys.Enter);

                /*did not need to change the required delivery date, because it was already 
                 set as tomorrow. e.g March 8 is the delivery date if today is March 7.*/

                //found out that I need to add something to "Delivery Address", in order to submit it successfully
                IWebElement addr = driver.FindElement(By.Id("AddressesFields_DeliveryAddress"));
                addr.SendKeys("Any");
                addr.SendKeys(Keys.Enter);

                //enters activity
                IWebElement act = driver.FindElement(By.Id("itemActivity"));
                act.SendKeys("ACCOM");
                Thread.Sleep(500);  //adding this solved the problem. The problem was that it could not register the job code.
                act.SendKeys(Keys.Enter);


                //enters line description
                IWebElement lineDesc = driver.FindElement(By.Id("itemDescription"));
                lineDesc.SendKeys("Any");
                lineDesc.SendKeys(Keys.Enter);

                //enters quantity
                IWebElement quant = driver.FindElement(By.Id("itemQuantity"));
                quant.SendKeys("2");
                quant.SendKeys(Keys.Enter);

                //enters cost
                IWebElement cost = driver.FindElement(By.Id("itemUnitCost"));
                cost.SendKeys("100");
                cost.SendKeys(Keys.Enter);

                //clicks SAVE
                IWebElement saveIcon = driver.FindElement(By.XPath("//*[@id='purchaseRequisitionEntry_Form']/div[3]/div[6]/div[2]/div/button/span[1]"));
                saveIcon.Click();
                Thread.Sleep(1000);

                //clicks SUBMIT
                IWebElement submitIcon = driver.FindElement(By.XPath("//*[@id='purchaseRequisitionEntry_Form']/div[7]/div[2]/div/button/span[1]"));
                submitIcon.Click();
                Thread.Sleep(1000);

                //Accepts the popup message
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                Thread.Sleep(2000);

            }
        }

        public void TestCase2() //This test case is where it shows error message because the minimum details are not completed
        {
            if (driver != null)
            {
                //enters job code
                IWebElement job = driver.FindElement(By.Id("GeneralFields_Job"));
                job.SendKeys("4112");
                Thread.Sleep(500); //adding this solved the problem. The problem was that it could not register the job code.
                job.SendKeys(Keys.Enter);

                //enters description
                IWebElement desc = driver.FindElement(By.Id("GeneralFields_Description"));
                desc.SendKeys("Any");
                desc.SendKeys(Keys.Enter);

                /*did not need to change the required delivery date, because it was already 
                 set as tomorrow. e.g March 8 is the delivery date if today is March 7.*/

                //********
                //This time I did not type anything to the "Delivery Address", in order to show a error message
                //********

                //enters activity
                IWebElement act = driver.FindElement(By.Id("itemActivity"));
                act.SendKeys("ACCOM");
                Thread.Sleep(500);  //adding this solved the problem. The problem was that it could not register the job code.
                act.SendKeys(Keys.Enter);


                //enters line description
                IWebElement lineDesc = driver.FindElement(By.Id("itemDescription"));
                lineDesc.SendKeys("Any");
                lineDesc.SendKeys(Keys.Enter);

                //enters quantity
                IWebElement quant = driver.FindElement(By.Id("itemQuantity"));
                quant.SendKeys("2");
                quant.SendKeys(Keys.Enter);

                //enters cost
                IWebElement cost = driver.FindElement(By.Id("itemUnitCost"));
                cost.SendKeys("100");
                cost.SendKeys(Keys.Enter);

                //clicks SAVE
                IWebElement saveIcon = driver.FindElement(By.XPath("//*[@id='purchaseRequisitionEntry_Form']/div[3]/div[6]/div[2]/div/button/span[1]"));
                saveIcon.Click();
                Thread.Sleep(1000);

                //clicks SUBMIT
                IWebElement submitIcon = driver.FindElement(By.XPath("//*[@id='purchaseRequisitionEntry_Form']/div[7]/div[2]/div/button/span[1]"));
                submitIcon.Click();
                Thread.Sleep(1000);

                //Accepts the popup message
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
                Thread.Sleep(2000);
            }
        }

        [TestMethod]
        public void ShutDown()
        {
            if (driver != null)
            {
                // closes the browser
                driver.Close(); 
            }
        }

    }

}
