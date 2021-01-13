namespace Framework.Pages.Common
{
    public abstract class NavigatableBasePage : BasePage
    {
        public abstract string Url { get; }

        public void Open()
        {
            //Navigation to another Url
            driver.Navigate().GoToUrl(Url);
        }
    }
}
