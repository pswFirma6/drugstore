using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace SeleniumTestProject
{
    public class AddOfferTest : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.AddOfferPage addOfferPage;
        private int offerCount;

        public AddOfferTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--whitelisted-ips=\"\"");

            driver = new ChromeDriver(options);

            addOfferPage = new Pages.AddOfferPage(driver);
            addOfferPage.Navigate();
            offerCount = addOfferPage.OfferCount();
            Assert.Equal(driver.Url, Pages.AddOfferPage.URI);

            Assert.True(addOfferPage.CreateButtonElementDisplayed());
            
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulSubmit()
        {
            addOfferPage.ShowOfferForm();

            if(!CheckIfDisplayed())
            {
                Assert.True(false);
            }

            addOfferPage.InsertOfferTitle("Test ponuda");
            addOfferPage.InsertOfferContent("Sadrzaj test ponude");
            addOfferPage.InsertStartDate("12/27/2021");
            addOfferPage.InsertEndDate("12/28/2021");
            addOfferPage.SubmitForm();

            Thread.Sleep(5000);

            Pages.AddOfferPage newAddOfferPage = new Pages.AddOfferPage(driver);
            Assert.Equal(offerCount + 1, newAddOfferPage.OfferCount());
        }

        [Fact]
        public void TestUnsuccessfulSubmitTitle()
        {
            addOfferPage.ShowOfferForm();

            if (!CheckIfDisplayed())
            {
                Assert.True(false);
            }

            addOfferPage.InsertOfferTitle("");
            addOfferPage.InsertOfferContent("Sadrzaj test ponude");
            addOfferPage.InsertStartDate("12/27/2021");
            addOfferPage.InsertEndDate("12/28/2021");
            addOfferPage.SubmitForm();

            Thread.Sleep(5000);

            Pages.AddOfferPage newAddOfferPage = new Pages.AddOfferPage(driver);
            Assert.Equal(offerCount, newAddOfferPage.OfferCount());
        }

        [Fact]
        public void TestUnsuccessfulSubmitContent()
        {
            addOfferPage.ShowOfferForm();

            if (!CheckIfDisplayed())
            {
                Assert.True(false);
            }

            addOfferPage.InsertOfferTitle("Test ponuda");
            addOfferPage.InsertOfferContent("");
            addOfferPage.InsertStartDate("12/27/2021");
            addOfferPage.InsertEndDate("12/28/2021");
            addOfferPage.SubmitForm();

            Thread.Sleep(5000);

            Pages.AddOfferPage newAddOfferPage = new Pages.AddOfferPage(driver);
            Assert.Equal(offerCount, newAddOfferPage.OfferCount());
        }

        [Fact]
        public void TestUnsuccessfulSubmitStartDate()
        {
            addOfferPage.ShowOfferForm();

            if (!CheckIfDisplayed())
            {
                Assert.True(false);
            }

            addOfferPage.InsertOfferTitle("Test ponuda");
            addOfferPage.InsertOfferContent("Sadrzaj test ponude");
            addOfferPage.InsertStartDate("");
            addOfferPage.InsertEndDate("12/28/2021");
            addOfferPage.SubmitForm();

            Thread.Sleep(5000);

            Pages.AddOfferPage newAddOfferPage = new Pages.AddOfferPage(driver);
            Assert.Equal(offerCount, newAddOfferPage.OfferCount());
        }

        [Fact]
        public void TestUnsuccessfulSubmitEndDate()
        {
            addOfferPage.ShowOfferForm();

            if (!CheckIfDisplayed())
            {
                Assert.True(false);
            }

            addOfferPage.InsertOfferTitle("Test ponuda");
            addOfferPage.InsertOfferContent("Sadrzaj test ponude");
            addOfferPage.InsertStartDate("12/27/2021");
            addOfferPage.InsertEndDate("");
            addOfferPage.SubmitForm();

            Thread.Sleep(5000);

            Pages.AddOfferPage newAddOfferPage = new Pages.AddOfferPage(driver);
            Assert.Equal(offerCount, newAddOfferPage.OfferCount());
        }

        private bool CheckIfDisplayed()
        {
            return (addOfferPage.OfferContentElementDisplayed() &&
                    addOfferPage.OfferTitleElementDisplayed() &&
                    addOfferPage.StartDateElementDisplayed() &&
                    addOfferPage.EndDateElementDisplayed() &&
                    addOfferPage.SubmitButtonElementDisplayed());
        }
    }
}
