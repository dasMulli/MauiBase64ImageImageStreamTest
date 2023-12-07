
using static MauiBase64ImageSample.MainPage;

namespace MauiBase64ImageSample;

public partial class TemplatePage : ContentPage
{
    bool didItOnce = false;
    MyObject TemplateObject;
    bool UseCacheFiles;
	public TemplatePage(MyObject myObject, bool useCacheFiles)
	{
		InitializeComponent();
        UseCacheFiles = useCacheFiles;
        TemplateObject = myObject;
       // LoadCards();
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetBackButtonTitle(this, null);
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync(true);
        return true;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        LoadCards(UseCacheFiles);
    }

    private void LoadCards(bool useCacheFiles)
    {
     if (!didItOnce)  
            didItOnce = true;
            VerticalStackLayout contentStack = new() { VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Start };

            for (int i = 0; i < 20; i++)
            {
                CardView cardView = new CardView(TemplateObject, $"{TemplateObject.Name} card #{i + 1}", useCacheFiles);
                contentStack.Add(cardView);
            }

            scroller.Content = contentStack;
     
        {
        }


    }


}