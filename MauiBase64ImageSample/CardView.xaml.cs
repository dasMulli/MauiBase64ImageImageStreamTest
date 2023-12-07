using static MauiBase64ImageSample.MainPage;

namespace MauiBase64ImageSample;

public partial class CardView : ContentView
{
    MyObject CardObject;
	public CardView(MyObject cardObject, string description, bool useCacheFile)
	{
		InitializeComponent();
        CardObject = cardObject;
        LblDescription.Text =description;
        if (useCacheFile)
            CardImage.Source = CardObject.CachedFileName;
        else
        {
            CardImage.Source = CardObject.AssetImageSource;
        }
	}
}