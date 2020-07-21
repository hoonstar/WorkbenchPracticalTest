using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace WorkbenchPracticalTest
{
    [TestClass]
    public class CreatePurchaseRequisition  //changed the public class name, to an appropriate name
    {
        IWebDriver driver;

        [TestMethod]
        public void OpenChrome()
        {   //Testing the first case
            StartTest();
            FirstTestCase();
            ShutDown();

            //testing the second case
            StartTest();
            SecondTestCase();
            ShutDown();
        }

        public void StartTest()
        {
            driver = new ChromeDriver();
            PreCondition();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
        public void FirstTestCase() //This test case is where the Purchase Requisition has been submitted successfully
        {
            if (driver != null)
            {
                EnterJobCode();
                EnterDescription();

                /*did not need to change the required delivery date, because it was already 
                 set as tomorrow. e.g March 8 is the delivery date if today is March 7.*/

                //found out that I need to add something to "Delivery Address", in order to submit it successfully
                EnterDeliveryAddress();

                EnterActivity();
                EnterLineDescription();
                EnterQuantity();
                EnterCost();

                ClickSave();
                ClickSubmit();

                AcceptPopUpMessage();
            }
        }

        [TestMethod]
        public void SecondTestCase() //This test case is where it shows error message because the minimum details are not completed
        {
            if (driver != null)
            {
                EnterJobCode();
                EnterDescription();

                /*did not need to change the required delivery date, because it was already 
                 set as tomorrow. e.g March 8 is the delivery date if today is March 7.*/

                //This time EnterDeliveryAddress() was not used, in order to show a error message

                EnterActivity();
                EnterLineDescription();
                EnterQuantity();
                EnterCost();

                ClickSave();
                ClickSubmit();

                AcceptPopUpMessage();
            }
        }

        public void EnterJobCode() 
        {
            IWebElement job = driver.FindElement(By.Id("GeneralFields_Job"));
            job.SendKeys("4112");
            SleepAndEnter(job);
        }

        public void EnterDescription() 
        {
            IWebElement desc = driver.FindElement(By.Id("GeneralFields_Description"));
            desc.SendKeys("Any");
            SleepAndEnter(desc);
        }

        public void EnterDeliveryAddress() 
        {
            IWebElement addr = driver.FindElement(By.Id("AddressesFields_DeliveryAddress"));
            addr.SendKeys("Any");
            SleepAndEnter(addr);
        }

        public void EnterActivity() 
        {
            IWebElement act = driver.FindElement(By.Id("itemActivity"));
            act.SendKeys("ACCOM");
            SleepAndEnter(act);
        }

        public void EnterLineDescription() 
        {
            IWebElement lineDesc = driver.FindElement(By.Id("itemDescription"));
            lineDesc.SendKeys("Any");
            SleepAndEnter(lineDesc);
        }

        public void EnterQuantity() 
        {
            IWebElement quant = driver.FindElement(By.Id("itemQuantity"));
            quant.SendKeys("2");
            SleepAndEnter(quant);
        }

        public void EnterCost() 
        {
            IWebElement cost = driver.FindElement(By.Id("itemUnitCost"));
            cost.SendKeys("100");
            SleepAndEnter(cost);
        }

        public void ClickSave() 
        {
            IWebElement saveIcon = driver.FindElement(By.XPath("//*[@id='purchaseRequisitionEntry_Form']/div[3]/div[6]/div[2]/div/button/span[1]"));
            //IWebElement saveIcon = driver.FindElement(By.ClassName("ui-button-text")); cannot use className because another button below, has the same className.
            ClickButton(saveIcon);
        }

        public void ClickSubmit() 
        {
            IWebElement submitIcon = driver.FindElement(By.XPath("//*[@id='purchaseRequisitionEntry_Form']/div[7]/div[2]/div/button/span[1]"));
            //IWebElement submitIcon = driver.FindElement(By.ClassName("ui-button-text")); Also, there is no button id that I can use as well.
            ClickButton(submitIcon);
        }

        public void AcceptPopUpMessage() 
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);
        }

        public void SleepAndEnter(IWebElement name) 
        {
            Thread.Sleep(500); 
            name.SendKeys(Keys.Enter);
        }

        public void ClickButton(IWebElement name) 
        {
            name.Click();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void ShutDown()
        {
            if (driver != null)
            {
                string message = "Test Case Passed";
                string title = "Result";
                System.Windows.MessageBox.Show(message, title);
                // closes the browser
                driver.Close();
            }
        }
    }

}
