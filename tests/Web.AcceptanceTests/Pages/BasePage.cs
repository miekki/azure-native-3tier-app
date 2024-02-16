namespace azure_native_3tier_app.Web.AcceptanceTests.Pages;

public abstract class BasePage
{
    public static string BaseUrl => ConfigurationHelper.GetBaseUrl();

    public abstract string PagePath { get; }

    public abstract IBrowser Browser { get; }

    public abstract IPage Page { get; set; }

    public async Task GotoAsync()
    {
        Page = await Browser.NewPageAsync(new BrowserNewPageOptions() { IgnoreHTTPSErrors = true });
        await Page.GotoAsync(PagePath);
    }
}
