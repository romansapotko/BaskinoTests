using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace AutomatedTestsBaskino.Pages
{
    class ProfilePage : AbstractPage
    {
        private const string BASE_URL = "http://baskino.club/user/test_baskino/";

        [FindsBy(How = How.XPath, Using = "//div[@class='avatar']")]
        private IWebElement imgProfile;

        [FindsBy(How = How.XPath, Using = "//input[@id='del_foto']")]
        private IWebElement checkboxDeletePhoto;

        [FindsBy(How = How.LinkText, Using = "редактировать профиль")]
        private IWebElement EditProfile;
        
       public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public bool isDefaultImg()
        {
            Console.WriteLine(imgProfile.GetAttribute("Src"));
            return imgProfile.GetAttribute("src").Equals("/templates/Baskino/images/noavatar.png");
        }
        public void EditProfileClick()
        {
            EditProfile.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public void LoadPicture()
        {
            IWebElement inputChooseFile = driver.FindElement(By.Name("image"));
            inputChooseFile.SendKeys(System.IO.Path.GetFullPath(@"D:\AutomatedTestsBaskino\AutomatedTestsBaskino\Images\fat.jpg"));
            System.Threading.Thread.Sleep(2000);
            

        }
        public void SubmitClick()
        {
            IWebElement buttonSubmit = driver.FindElement(By.Name("submit"));
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(2000);
        }
     
        public void SetCheckboxDeletePhoto()
        {
            checkboxDeletePhoto.Click();
        }
        public void EnterNewPasswordInfo(string oldPassword,string newPassword)
        {
            IWebElement inputOldPassword = driver.FindElement(By.Name("altpass"));
            inputOldPassword.SendKeys(oldPassword);
            IWebElement inputNewPassword = driver.FindElement(By.Name("password1"));
            inputNewPassword.SendKeys(newPassword);
            IWebElement inputRepeat = driver.FindElement(By.Name("password2"));
            inputRepeat.SendKeys(newPassword);
        }
    }
}
