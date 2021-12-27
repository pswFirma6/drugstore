using FakePharmacy.Controller;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using Xunit;

namespace SeleniumTestProject
{
    public class AddHospitalTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.AddHospitalPage addHospitalPage;
        private int hospitalsCount;
        private HospitalService hospitalService;

        public AddHospitalTests()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            IHospitalRepository irepo = new HospitalRepository(databaseContext);
            hospitalService = new HospitalService(irepo);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            addHospitalPage = new Pages.AddHospitalPage(driver);
            addHospitalPage.Navigate();
            hospitalsCount = addHospitalPage.HospitalsCount();
            Assert.Equal(driver.Url, Pages.AddHospitalPage.URI);

            Assert.True(addHospitalPage.HospitalNameElementDisplayed());
            Assert.True(addHospitalPage.HospitalAddressElementDisplayed());
            Assert.True(addHospitalPage.HospitalCityDisplayedElement());
            Assert.True(addHospitalPage.AddButtonElementDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulSubmit()
        {
            addHospitalPage.InsertHospitalName("Nekaa");
            addHospitalPage.InsertHospitalAddress("Neka adresa 123");
            addHospitalPage.InsertHospitalCity("Novi Sad");
            addHospitalPage.SubmitForm();

            Thread.Sleep(10000);

            Pages.AddHospitalPage newAddHospitalPage = new Pages.AddHospitalPage(driver);
            Assert.Equal(hospitalsCount + 1, newAddHospitalPage.HospitalsCount());
        }

        [Fact]
        public void TestUnsuccessfulSubmit()
        {
            addHospitalPage.InsertHospitalName("");
            addHospitalPage.InsertHospitalAddress("Neka adresa 123");
            addHospitalPage.InsertHospitalCity("Novi Sad");
            addHospitalPage.SubmitForm();

            Thread.Sleep(10000);

            Pages.AddHospitalPage newAddHospitalPage = new Pages.AddHospitalPage(driver);
            Assert.Equal(hospitalsCount, newAddHospitalPage.HospitalsCount());
        }


        [Fact]
        public void TestExistingHospitalSubmit()
        {
            hospitalService.AddHospital(new Hospital(0, "Neka bolnica", null, null));
            hospitalsCount += 1;

            addHospitalPage.InsertHospitalName("Neka bolnica");
            addHospitalPage.InsertHospitalAddress("Neka adresa 123");
            addHospitalPage.InsertHospitalCity("Novi Sad");
            addHospitalPage.SubmitForm();

            Thread.Sleep(10000);

            Pages.AddHospitalPage newAddHospitalPage = new Pages.AddHospitalPage(driver);
            Assert.Equal(hospitalsCount, newAddHospitalPage.HospitalsCount());


        }

    }
}
