using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace AutomatedTestsBaskino.Pages
{
    class FilmPage : AbstractPage
    {
        private const string BASE_URL = "http://baskino.club/films/biograficheskie/484-spisok-shindlera.html";
        private const string FILM_NAME = "Список Шиндлера";
        
        [FindsBy(How = How.ClassName, Using = "favorites_add")]
        private IWebElement buttonAddFavourite;
        [FindsBy(How = How.ClassName, Using = "favorites_remove")]
        private IWebElement buttonRemoveFavourite;
        [FindsBy(How = How.ClassName, Using = "r10-unit")]
        private IWebElement buttonRate10;        

        public FilmPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public void AddFavouriteClick()
        {
            System.Threading.Thread.Sleep(2000);
            buttonAddFavourite.Click();
        }
        public void RemoveFromFavourites()
        {
            System.Threading.Thread.Sleep(2000);
            buttonRemoveFavourite.Click();
        }
        public bool isFavourite()
        {

            return buttonRemoveFavourite.Text.Equals("Удалить из закладок");
        }
        public bool isDeletedFromFavourite()
        {

            return buttonAddFavourite.Text.Equals("Добавить в закладки");
        }
       
        public void Rate()
        {
            buttonRate10.Click();
        }
       
        
       
       
    }
}
