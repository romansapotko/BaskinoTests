using System;
using NUnit.Framework;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace AutomatedTestsBaskino
{
   
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "test_baskino";
        private const string PASSWORD = "123123123";
        private const string TEXT_TO_SEARCH = "Список Шиндлера";
        private const string NAVIGATION_LINK = "Драмы";
        private const string NEW_PASSWORD = "12345678";
        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]

        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void Login()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            Assert.True(steps.IsLogin());
        }

        [Test]
        public void LogOff()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            steps.LogOffBaskino();
            Assert.True(steps.IsLoggedOff());

        }

        [Test]
        public void Search()
        {
            steps.SearchFilm(TEXT_TO_SEARCH);
            Assert.True(steps.IsSearchedFilm(TEXT_TO_SEARCH));
        }

        [Test]
        public void RateFilmTest()
        {
            steps.RateFilm();
        }

        [Test]
        public void AddToFavourites()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            steps.AddFavourite();
            Assert.True(steps.IsAddedToFavourites());
            steps.DeleteFavorite();
        }

        [Test]
        public void DeleteFromFavourites()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            steps.AddFavourite();
            steps.DeleteFavorite();
            Assert.True(steps.IsDeletedFavourite());
        }

        [Test]
        public void NavigationPanelTest()
        {
            steps.GoThroughPanel(NAVIGATION_LINK);
            Assert.True(steps.IsHistoryPage(NAVIGATION_LINK));
        }
        [Test]
        public void AddAvatar()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            steps.ChangeAvatar();
            Assert.False(steps.IsDefaultAvatar());
            steps.DeleteAvatar();
        }
        [Test]
        public void DeleteAvatar()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            steps.ChangeAvatar();
            steps.DeleteAvatar();
            Assert.True(steps.IsDefaultAvatar());
        }

        [Test]
        public void ChangePassword()
        {
            steps.LoginBaskino(USERNAME, PASSWORD);
            steps.ChangePassword(PASSWORD, NEW_PASSWORD);
            steps.LogOffBaskino();
            steps.LoginBaskino(USERNAME, NEW_PASSWORD);
            Assert.True(steps.IsLogin());
            steps.ChangePassword(NEW_PASSWORD, PASSWORD);
        }



    }
}
