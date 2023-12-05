using static MauiBase64ImageSample.MainPage;

namespace MauiBase64ImageSample;

public partial class CardView : ContentView
{
    MyObject CardObject;
	public CardView(MyObject cardObject, string description)
	{
		InitializeComponent();
        CardObject = cardObject;
        LblDescription.Text =description;
        CardImage.Source = CardObject.AssetImageSource;
	}
}