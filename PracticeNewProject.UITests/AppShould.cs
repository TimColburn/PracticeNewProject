using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace PracticeNewProject.UITests
{
    public class AppShould
    {
        const string urlStudentsIndex = "https://localhost:44315/Students/Index";
        const string pageTitle = "localhost";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

                driver.Navigate().GoToUrl(urlStudentsIndex);

                wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Create New"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("UserName"))).SendKeys("TimSelenium");
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Password"))).SendKeys("PasswordSelenium");
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("male"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("IdAddress"))).SendKeys("1234 Main");

                IWebElement courseDropDownList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("CourseId")));
                var courseSelectElement = new SelectElement(courseDropDownList);
                courseSelectElement.SelectByValue("2");

                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[name='SelectedHobbyIds'][value='2']"))).Click();

                IWebElement skillsDropDownList = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("SelectedSkillIds")));
                var skillsSelectElement = new SelectElement(skillsDropDownList);
                skillsSelectElement.SelectByValue("2");
                skillsSelectElement.SelectByValue("4");

                Thread.Sleep(3000);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='submit'][value='Submit']"))).Click();
                Thread.Sleep(5000);

                //Assert.Equal(urlPeopleIndex, driver.Url);
                //Assert.Equal(pageTitle, driver.Title);
            }
        }
    }
}
