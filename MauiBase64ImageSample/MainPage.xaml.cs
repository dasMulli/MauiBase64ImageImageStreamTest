
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
        int number;
        //get inputbox for number
        string result = await this.DisplayPromptAsync("Pages to open", "Enter a number:", "OK", "Cancel","10",2,Keyboard.Numeric,"10");
        if (result != null)
        {
            if(int.TryParse(result, out number))
            {
                OpenPages(number +1);

            }
            else
            {
                OpenPages(11);
            }           
        }
    }

    private async void OpenPages(int number)
    {
        for (int i = 0; i < number; i++)
        {
            MyObject myObject = new()
            {
                AssetImageString = Base64ImageProvider.Base64EncodedImage,
                Name = $"Page {i}"
            };

            await Navigation.PushAsync(new TemplatePage(myObject));
        }
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //if (!didItOnce)
        //{
        //    didItOnce = true;
        //    OpenPages(6);
        //}
    }

    public class MyObject
    {
        public string Name { get; set; }
        public string AssetImageString { get; set; }
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

