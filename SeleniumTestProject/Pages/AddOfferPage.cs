using OpenQA.Selenium;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestProject.Pages
{
    class AddOfferPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/offers";
        private IWebElement CreateButtonElement => driver.FindElement(By.Id("createButton"));
        private IWebElement OfferContentElement => driver.FindElement(By.Id("offerContent"));
        private IWebElement OfferTitleElement => driver.FindElement(By.Id("offerTitle"));
        private IWebElement StartDateElement => driver.FindElement(By.Id("startDate"));
        private IWebElement EndDateElement => driver.FindElement(By.Id("endDate"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submitButton"));
        private OfferService offerService;

        public AddOfferPage(IWebDriver driver)
        {
            this.driver = driver;
            DatabaseContext databaseContext = new DatabaseContext();
            IOfferRepository irepo = new OfferRepository(databaseContext);
            this.offerService = new OfferService(irepo);
        }

        public bool CreateButtonElementDisplayed()
        {
            return CreateButtonElement.Displayed;
        }

        public bool OfferContentElementDisplayed()
        {
            return OfferContentElement.Displayed;
        }

        public bool OfferTitleElementDisplayed()
        {
            return OfferTitleElement.Displayed;
        }

        public bool StartDateElementDisplayed()
        {
            return StartDateElement.Displayed;
        }

        public bool EndDateElementDisplayed()
        {
            return EndDateElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void ShowOfferForm()
        {
            CreateButtonElement.Click();
        }

        public void InsertOfferTitle(string title)
        {
            OfferTitleElement.SendKeys(title);
        }

        public void InsertOfferContent(string content)
        {
            OfferContentElement.SendKeys(content);
        }

        public void InsertStartDate(string startDate)
        {
            StartDateElement.SendKeys(startDate);
        }

        public void InsertEndDate(string endDate)
        {
            EndDateElement.SendKeys(endDate);
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public int OfferCount()
        {
            return offerService.GetOffers().Count;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
