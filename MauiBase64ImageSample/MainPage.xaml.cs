

namespace MauiBase64ImageSample;

public partial class MainPage : ContentPage
{
    bool didItOnce = false;

	public MainPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetBackButtonTitle(this, null);

    }

    private async void OnDoThingsClicked(object sender, EventArgs e)
	{
        await OpenPages(await GetNumber());
    }

    private async Task<int> GetNumber()
    {
        int number = 11;
        //get inputbox for number
        string result = await this.DisplayPromptAsync("Pages to open", "Enter a number:", "OK", "Cancel", "10", 2, Keyboard.Numeric, "2");
        if (result != null)
        {
            if (int.TryParse(result, out number))
            {
                if (number < 2)
                    number = 2;
               

            }
        }
        return number;
    }

    private async Task OpenPages(int number, bool useCacheFiles = false)
    {
        for (int i = 0; i < number; i++)
        {
            MyObject myObject = new()
            {
                AssetImageString = Base64ImageProvider.Base64EncodedImage,
                CachedFileName = await Base64ImageProvider.SaveImageToCache(Base64ImageProvider.Base64EncodedImage),
                Name = $"Page {i + 1}"
            };

            await Navigation.PushAsync(new TemplatePage(myObject, useCacheFiles));
        }
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private async void OnDoThingsFromCacheClicked(object sender, EventArgs e)
    {
        await OpenPages(await GetNumber(), true);
    }

    public class MyObject
    {
        public string Name { get; set; }
        public string AssetImageString { get; set; }
        public string CachedFileName { get; set; }
        public ImageSource AssetImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(AssetImageString))
                {
                    return null;
                }
                else
                {
                    ImageSource image = Base64ImageProvider.ConvertToImageSource(AssetImageString);
                    return image;
                }
            }
        }

    }

}

