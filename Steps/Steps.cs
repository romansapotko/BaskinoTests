using System;
using OpenQA.Selenium;

namespace AutomatedTestsBaskino.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginBaskino(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);

        }
        public bool IsLogin()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isAccountButtonExists();
        }

        public void LogOffBaskino()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.LogOff();
        }
        public bool IsLoggedOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isEnterButtonExists();
        }

        public bool IsSearchedFilm(string filmName)
        {
            Pages.MainPage searchPage = new Pages.MainPage(driver);

            return searchPage.GetFindFilm(filmName).Trim().ToLower().Equals(filmName.Trim().ToLower());
        }
        public void SearchFilm(string filmName)
        {
            Pages.MainPage searchPage = new Pages.MainPage(driver);
            searchPage.OpenPage();
            searchPage.Search(filmName);
        }


        public void RateFilm()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.Rate();
        }


       

        public void AddFavourite()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddFavouriteClick();
         
        }
        
        public bool IsAddedToFavourites()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);

            return filmPage.isFavourite();
        }
        
        public void DeleteFavorite()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.RemoveFromFavourites();
        }
        public bool IsDeletedFavourite()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isDeletedFromFavourite();
        }

        public void ChangeAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.LoadPicture();
            profilePage.SubmitClick();

        }
        public bool IsDefaultAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isDefaultImg();
        }
        public void DeleteAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.SetCheckboxDeletePhoto();
            profilePage.SubmitClick();
        }
        //public bool IsLoggedError()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(driver);
        //    Console.WriteLine(mainPage.GetAuthorizationError());
        //    return (mainPage.GetAuthorizationError().Equals("Ошибка авторизации"));
        //}
        public void GoThroughPanel(string filmType)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.GoThroughPanel(filmType);
        }
        public bool IsHistoryPage(string filmType)
        {
            IWebElement pageHeader = driver.FindElement(By.CssSelector(".htitlen > h2:nth-child(1)"));
            Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals(filmType +" смотреть онлайн");
        }
       
        
        
       
       
        public void ChangePassword(string oldPassword,string newPassword)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.EnterNewPasswordInfo(oldPassword, newPassword);
            profilePage.SubmitClick();

        }
    }
}
