using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace AutomatedTestsBaskino.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://baskino.club/index.php";

        
        
        [FindsBy(How = How.LinkText, Using = "Вход")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.Id, Using = "login_name")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//input[@class='fbutton']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.LinkText, Using = "Аккаунт")]
        private IWebElement Account;
        [FindsBy(How = How.LinkText, Using = "Выход")]
        private IWebElement Exit;

        //Для поиска фильма
        [FindsBy(How = How.XPath, Using = "//input[@id='story']")]
        private IWebElement inputSearch;

        [FindsBy(How = How.ClassName, Using = "find-button")]
        private IWebElement buttonStartSearch;

        IWebElement linkFilm;

        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }



        public void Login(string username, string password)
        {
            buttonEnter.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();            
            System.Threading.Thread.Sleep(1000);
        }
        public void LogOff()
        {
            Account.Click();
            Exit.Click();
          }
      
        
        public bool isEnterButtonExists()
        {
            return buttonEnter.Text.Equals("Вход");
        }
        public bool isAccountButtonExists()
        {
            return Account.Text.Equals("Аккаунт");
        }
        public void GoThroughPanel(string filmType)
        {
            IWebElement linkPanel = driver.FindElement(By.LinkText(filmType));
            Console.WriteLine(linkPanel.Text);
            linkPanel.Click();
        }

        public void Search(string text)
        {
            inputSearch.SendKeys(text);
            buttonStartSearch.Click();
        }

        public string GetFindFilm(string film_name)
        {
            linkFilm = driver.FindElement(By.LinkText(film_name));
            Console.WriteLine(linkFilm.Text);
            return linkFilm.Text;
        }
    }
}
