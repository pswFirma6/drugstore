using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTestProject.Pages
{
    public class AddHospitalPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/hospitalRegistration";
        private IWebElement HospitalNameElement => driver.FindElement(By.Id("hospitalName"));
        private IWebElement HospitalAddressElement => driver.FindElement(By.Id("hospitalAddress"));
        private IWebElement HospitalCityElement => driver.FindElement(By.Id("hospitalCity"));
        private IWebElement AddButtonElement => driver.FindElement(By.Id("addHospital"));
        private List<Hospital> hospitals = new List<Hospital>();
        private HospitalService hospitalService;
        private IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        private readonly IConfiguration _config;

        public AddHospitalPage(IWebDriver driver)
        {
            this.driver = driver;
            DatabaseContext databaseContext = new DatabaseContext();
            IHospitalRepository irepo = new HospitalRepository(databaseContext);
            hospitalService = new HospitalService(irepo);
            this.hospitals = hospitalService.GetAll();

            _config = configurationBuilder.Build();
        }

        public bool HospitalNameElementDisplayed()
        {
            return HospitalNameElement.Displayed;
        }

        public bool HospitalAddressElementDisplayed()
        {
            return HospitalAddressElement.Displayed;
        }

        public bool HospitalCityDisplayedElement()
        {
            return HospitalCityElement.Displayed;
        }

        public bool AddButtonElementDisplayed()
        {
            return AddButtonElement.Displayed;
        }

        public void InsertHospitalName(string name)
        {
            HospitalNameElement.SendKeys(name);
        }

        public void InsertHospitalAddress(string address)
        {
            HospitalAddressElement.SendKeys(address);
        }

        public void InsertHospitalCity(string city)
        {
            HospitalCityElement.SendKeys(city);
        }

        public void SubmitForm()
        {
            AddButtonElement.Click();
        }

        public int HospitalsCount()
        {
            return hospitals.Count;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
