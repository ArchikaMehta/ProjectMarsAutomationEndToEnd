using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.CommonHelpers;

namespace Framework.Pages.Profile.Sections
{
    public class MainProfileSection : Driver
    {
        //Web element for Profile Name which is the benchmark to verify all contents 
        private IWebElement profileName => driver.FindElement(By.ClassName("title"));

        //Web element for Language Tab
        private IWebElement LanguageTab => driver.FindElement(By.XPath("//a[@data-tab='first']"));

        //Web element for Add new to add new Language
        private IWebElement LanguageAddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='first']//div[contains(text(),'Add New')]"));

        //Web element for Enter the Language on text box
        private IWebElement LanguageName => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        //Web element for Enter the Language on text box
        private IWebElement LanguageDropdownBox => driver.FindElement(By.XPath("//div[@data-tab='first']//select[@name='level']"));

        //Web element for Add Language
        private IWebElement LanguageAddBtn => driver.FindElement(By.XPath("//div[@data-tab='first']//input[@value='Add']"));

        //Web element for Delete Language
        private IWebElement LanguageDeleteBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[2]//div[2]//tbody[last()]/tr/td[3]/span[2]/i"));

        //Web element for Click Skills Tab
        private IWebElement SkillTab => driver.FindElement(By.XPath("//a[@data-tab='second']"));

        //Web element for Add new to add new skill
        private IWebElement SkillAddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='second']//div[contains(text(),'Add New')]"));

        //Web element for Enter the Skill on text box
        private IWebElement SkillName => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));

        //Web element for skill level dropdown
        private IWebElement SkillDropdownBox => driver.FindElement(By.XPath("//div[@data-tab='second']//select[@name='level']"));

        //Web element for Add Skill
        private IWebElement SkillAddBtn => driver.FindElement(By.XPath("//div[@data-tab='second']//input[@value='Add']"));

        //Web element for Delete Skill
        private IWebElement SkillDeleteBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[3]//div[2]//tbody[last()]/tr/td[3]/span[2]/i"));

        //Web element for Education Tab
        private IWebElement EducationTab => driver.FindElement(By.XPath("//a[@data-tab='third']"));

        //Web element for Add new to Educaiton
        private IWebElement EducationAddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='third']//div[contains(text(),'Add New')]"));

        //Web element for university in the text box
        private IWebElement EducationName => driver.FindElement(By.XPath("//input[@name='instituteName']"));

        //Web element for country dropdown
        private IWebElement EducationCountryDropdownBox => driver.FindElement(By.XPath("//select[@name='country']"));

        //Web element for Title dropdown
        private IWebElement EducationTitleDropdownBox => driver.FindElement(By.XPath("//select[@name='title']"));

        //Web element for Degree
        private IWebElement EducationDegree => driver.FindElement(By.XPath("//input[@name='degree']"));

        //Web element for Year of graduation dropdown box
        private IWebElement EducationGraduationYearDropdownBox => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));

        //Web element for Click Add button
        private IWebElement EducationAddBtn => driver.FindElement(By.XPath("//div[@data-tab='third']//input[@value='Add']"));

        //Web element for Delete Education
        private IWebElement EducationDeleteBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[4]//div[2]//tbody[last()]/tr/td[6]/span[2]/i"));

        //Web element for Certification Tab
        private IWebElement CertificationTab => driver.FindElement(By.XPath("//a[@data-tab='fourth']"));

        //Web element for Add New Button
        private IWebElement CertificationAddNewBtn => driver.FindElement(By.XPath("//div[@data-tab='fourth']//div[contains(text(),'Add New')]"));

        //Web element for Certification Name
        private IWebElement CertificationName => driver.FindElement(By.XPath("//input[@name='certificationName']"));

        //Web element for Certified from
        private IWebElement CertificationFrom => driver.FindElement(By.XPath("//input[@name='certificationFrom']"));

        //Web element for Year dropdown box
        private IWebElement CertificationYearDropdownBox => driver.FindElement(By.XPath("//select[@name='certificationYear']"));

        //Web element for Add Ceritification
        private IWebElement CertificationAddBtn => driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@value='Add']"));

        //Web element for  Delete Certificate
        private IWebElement CertificateDeleteBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[5]//div[2]//tbody[last()]/tr/td[4]/span[2]/i"));

        //Web element for Success message and for message close button
        private IWebElement Message => driver.FindElement(By.CssSelector("div.ns-box.ns-growl.ns-effect-jelly.ns-type-success.ns-show"));
        private IWebElement MessageClose => driver.FindElement(By.CssSelector("a.ns-close"));

        public void ProfileLanguageTab()
        {
            //Click on the Langauage tab for adding the new entry
            LanguageTab.Click();
        }

        public void EnterProfileLanguage()
        {
            // Populate data from Excel 
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

        #region Enter Language 
            //Click Add New
            LanguageAddNewBtn.Click();
            //Enter Language
            LanguageName.SendKeys(ExcelLibHelpers.ReadData(3, "Column0"));
            //Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
            LanguageDropdownBox.Click();
            new SelectElement(LanguageDropdownBox).SelectByText(ExcelLibHelpers.ReadData(3, "Column1")); // Need using OpenQA.Selenium.Support.UI;
            //Click Add
            LanguageAddBtn.Click();
        #endregion
        }

        public void ProfileSkillTab()
        {
            //Click Skills tab
            SkillTab.Click();
        }

        public void EnterProfileSkill()
        {
            // Populate data from Excel 
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

        #region Enter Skills
            //Click Add New
            SkillAddNewBtn.Click();
            //Enter Skill
            SkillName.SendKeys(ExcelLibHelpers.ReadData(3, "Column3"));
            //Choose Skill level 0-beginer; 1-intermediate; 2-expert
            SkillDropdownBox.Click();
            new SelectElement(SkillDropdownBox).SelectByText(ExcelLibHelpers.ReadData(3, "Column4"));
            //Click Add
            SkillAddBtn.Click();
        #endregion
        }

        public void ProfileEducationTab()
        {
            //Click Education tab
            EducationTab.Click();
        }

        public void EnterProfileEducation()
        {
            // Populate data from Excel 
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

        #region Enter Education
            //Click Add New
            EducationAddNewBtn.Click();
            //Enter University Name
            EducationName.SendKeys(ExcelLibHelpers.ReadData(3, "Column6"));
            //Enter Degree
            EducationDegree.SendKeys(ExcelLibHelpers.ReadData(3, "Column9"));
            //Choose Country
            EducationCountryDropdownBox.Click();
            new SelectElement(EducationCountryDropdownBox).SelectByText(ExcelLibHelpers.ReadData(3, "Column7"));
            //Choose  Title 0-Associate; 1-B.A; 2-BArch; 3-BFA; 4-B.Sc...
            EducationTitleDropdownBox.Click();
            new SelectElement(EducationTitleDropdownBox).SelectByText(ExcelLibHelpers.ReadData(3, "Column8"));
            //Choose Year
            EducationGraduationYearDropdownBox.Click();
            new SelectElement(EducationGraduationYearDropdownBox).SelectByText(ExcelLibHelpers.ReadData(3, "Column10"));
            //Click Add
            EducationAddBtn.Click();
        #endregion
        }

        public void ProfileCertificationTab()
        {
            //Click Certifications tab
            CertificationTab.Click();
        }

        public void EnterProfileCertification()
        {
            // Populate data from Excel 
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

        #region Enter Certifications
            //Click Add New
            CertificationAddNewBtn.Click();
            //Enter Certificate name
            CertificationName.SendKeys(ExcelLibHelpers.ReadData(3, "Column12"));
            //Enter Issuing place
            CertificationFrom.SendKeys(ExcelLibHelpers.ReadData(3, "Column13"));
            //Choose Year
            CertificationYearDropdownBox.Click();
            new SelectElement(CertificationYearDropdownBox).SelectByText(ExcelLibHelpers.ReadData(3, "Column14"));
            //Click Add
            CertificationAddBtn.Click();
        #endregion
        }

        public void SuccessMessage()
        {
            //Wait for success message to appear
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "CssSelector", "div.ns-box.ns-growl.ns-effect-jelly.ns-type-success.ns-show", 10);
            //Comparing success message text for skill add  
            Assert.IsTrue(Message.Text.Contains("has been added"));
            //Close success message
            MessageClose.Click();
        }

        public void VerifyEnterProfileLanguage()
        {
            //Populate data saved in Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

            //Refresh the page
            driver.Navigate().Refresh();
            //Wait for all text present in Element
            WaitHelpers.WaitForTextPresentInElement(driver, profileName, ExcelLibHelpers.ReadData(3, "Column18"), 10);

        #region Verify Enter Language            
            //Verify Language Name
            var lastRowLanguageName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.IsTrue(lastRowLanguageName.Contains(ExcelLibHelpers.ReadData(3, "Column0")));

            //Verify Language Level
            var lastRowLanguageLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.IsTrue(lastRowLanguageLevel.Contains(ExcelLibHelpers.ReadData(3, "Column1")));
        #endregion
        }

        public void VerifyEnterProfileSkills()
        {
            //Populate data saved in Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

            //Refresh the page
            driver.Navigate().Refresh();
            //Wait for all text present in Element
            WaitHelpers.WaitForTextPresentInElement(driver, profileName, ExcelLibHelpers.ReadData(3, "Column18"), 10);

        #region Verify Skills            
            //Jump to Skill tab
            SkillTab.Click();

            //Verify Skill Name
            var lastRowSkillName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.IsTrue(lastRowSkillName.Contains(ExcelLibHelpers.ReadData(3, "Column3")));

            //Verify Skill Level
            var lastRowSkillLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.IsTrue(lastRowSkillLevel.Contains(ExcelLibHelpers.ReadData(3, "Column4")));
        #endregion
        }

        public void VerifyEnterProfileEducation()
        {
            //Populate data saved in Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

            //Refresh the page
            driver.Navigate().Refresh();
            //Wait for all text present in Element
            WaitHelpers.WaitForTextPresentInElement(driver, profileName, ExcelLibHelpers.ReadData(3, "Column18"), 10);

        #region Verify Education            
            //Jump to Education tab
            EducationTab.Click();
            //Verify Education Country
            var lastRowEducationCountry = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.IsTrue(lastRowEducationCountry.Contains(ExcelLibHelpers.ReadData(3, "Column7")));

            //Verify Education Name
            var lastRowEducationName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.IsTrue(lastRowEducationName.Contains(ExcelLibHelpers.ReadData(3, "Column6")));

            //Verify Education Title
            var lastRowEducationTitle = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[3]")).Text;
            Assert.IsTrue(lastRowEducationTitle.Contains(ExcelLibHelpers.ReadData(3, "Column8")));

            //Verify Education Degree
            var lastRowEducationDegree = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[4]")).Text;
            Assert.IsTrue(lastRowEducationDegree.Contains(ExcelLibHelpers.ReadData(3, "Column9")));

            //Verify Education Graduation Year
            var lastRowEducationGraduationYear = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[5]")).Text;
            Assert.IsTrue(lastRowEducationGraduationYear.Contains(ExcelLibHelpers.ReadData(3, "Column10")));
        #endregion
        }

        public void VerifyEnterProfileCertifications()
        {
            //Populate data saved in Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

            //Refresh the page
            driver.Navigate().Refresh();
            //Wait for all text present in Element
            WaitHelpers.WaitForTextPresentInElement(driver, profileName, ExcelLibHelpers.ReadData(3, "Column18"), 10);

        #region Verify Certifications            
            //Jump to Certification tab
            CertificationTab.Click();
            //Verify Certificate Name
            var lastRowCertificateName = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[5]//div[2]//tbody[last()]/tr/td[1]")).Text;
            Assert.IsTrue(lastRowCertificateName.Contains(ExcelLibHelpers.ReadData(3, "Column12")));

            //Verify Certificate Issuing Place
            var lastRowCertificateFrom = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[5]//div[2]//tbody[last()]/tr/td[2]")).Text;
            Assert.IsTrue(lastRowCertificateFrom.Contains(ExcelLibHelpers.ReadData(3, "Column13")));

            //Verify Certificate Year
            var lastRowCertificateYear = driver.FindElement(By.XPath("//*[@id='account-profile-section']" + "/div/section[2]//div[3]/form/div[5]//div[2]//tbody[last()]/tr/td[3]")).Text;
            Assert.IsTrue(lastRowCertificateYear.Contains(ExcelLibHelpers.ReadData(3, "Column14")));
        #endregion
        }

        #region Delete Profile 
        public void DeleteProfile()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

            //Wait for all text present in Element
            WaitHelpers.WaitForTextPresentInElement(driver, profileName, ExcelLibHelpers.ReadData(3, "Column18"), 10);

        #region Delete Language            
            //Delete the last record
            LanguageTab.Click();
            LanguageDeleteBtn.Click();            
        #endregion

        #region Delete Skills            
            //Delete last record
            SkillTab.Click();
            SkillDeleteBtn.Click();            
        #endregion

        #region Delete Education            
            //Delete last record
            EducationTab.Click();
            EducationDeleteBtn.Click();        
        #endregion

        #region Delete Certification            
            //Delete last record
            CertificationTab.Click();
            CertificateDeleteBtn.Click();
        #endregion
        }
        #endregion

        #region Verify Delete-Profile 
        public void VerifyDeleteProfile()
        {            
            //Populate data saved in Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

            //Refresh the page
            driver.Navigate().Refresh();
            //Wait for all text present in Element
            WaitHelpers.WaitForTextPresentInElement(driver, profileName, ExcelLibHelpers.ReadData(3, "Column18"), 10);

        #region Verify Delete Language
            //Jump to Language tab
            LanguageTab.Click();
            //Read data saved in Excel
            var languageExcel = ExcelLibHelpers.ReadData(3, "Column1");
            try 
            { 
                //Find the last row data             
                driver.FindElement(By.XPath("//div[@data-tab='first']" + "//table/tbody[last()]/tr//*[contains(text(), '" + languageExcel + "')]"));
                Assert.Fail("Failed to delete language");
            }
            catch (NoSuchElementException)
            {
            }
        #endregion

        #region Verify Delete Skills
            //Jump to Skill tab
            SkillTab.Click();
            //Read Skill saved in Excel
            var skillExcel = ExcelLibHelpers.ReadData(3, "Column3");
            try
            { 
                //Check the last row data
                driver.FindElement(By.XPath("//div[@data-tab='second']" + "//table/tbody[last()]/tr//*[contains(text(), '" + skillExcel + "')]"));
                Assert.Fail("Failed to delete skill");
            }
            catch (NoSuchElementException)
            {
            }
        #endregion

        #region Verify Delete Education
            //Jump to Education tab
            EducationTab.Click();

            //Read Education info saved in excel
            var instituteNameExcel = ExcelLibHelpers.ReadData(3, "Column6");
            var instituteCountryExcel = ExcelLibHelpers.ReadData(3, "Column7");
            var instituteTitleExcel = ExcelLibHelpers.ReadData(3, "Column8");
            var instituteDegreeExcel = ExcelLibHelpers.ReadData(3, "Column9");
            var instituteGraduateYearExcel = ExcelLibHelpers.ReadData(3, "Column10");
            try 
            { 
                //Find the last row data
                driver.FindElement(By.XPath("//div[@data-tab='third']" + "//table/tbody[last()]/tr//*[contains(text(), '" + instituteCountryExcel + "')]"));
                driver.FindElement(By.XPath("//div[@data-tab='third']" + "//table/tbody[last()]/tr//*[contains(text(), '" + instituteTitleExcel + "')]"));
                driver.FindElement(By.XPath("//div[@data-tab='third']" + "//table/tbody[last()]/tr//*[contains(text(), '" + instituteDegreeExcel + "')]"));
                driver.FindElement(By.XPath("//div[@data-tab='third']" + "//table/tbody[last()]/tr//*[contains(text(), '" + instituteGraduateYearExcel + "')]"));
                driver.FindElement(By.XPath("//div[@data-tab='third']" + "//table/tbody[last()]/tr//*[contains(text(), '" + instituteNameExcel + "')]"));

                Assert.Fail("Failed to delete education.");
            }
            catch (NoSuchElementException)
            {
            }
        #endregion

        #region Verify Delete Certificate
            //Jump to Certification tab
            CertificationTab.Click();

            //Read Education info saved in excel
            var certificateNameExcel = ExcelLibHelpers.ReadData(3, "Column12");
            var certificateFromExcel = ExcelLibHelpers.ReadData(3, "Column13");
            var certificateYearExcel = ExcelLibHelpers.ReadData(3, "Column14");
            try
            { 
                //Find the last row data
                driver.FindElement(By.XPath("//div[@data-tab='fourth']" + "//table/tbody[last()]/tr//*[contains(text(), '" + certificateNameExcel + "')]"));
                driver.FindElement(By.XPath("//div[@data-tab='fourth']" + "//table/tbody[last()]/tr//*[contains(text(), '" + certificateFromExcel + "')]"));
                driver.FindElement(By.XPath("//div[@data-tab='fourth']" + "//table/tbody[last()]/tr//*[contains(text(), '" + certificateYearExcel + "')]"));

                Assert.Fail("Failed to delete certificate.");
            }
            catch (NoSuchElementException)
            {
            }
        #endregion
        }
        #endregion
    }
}


