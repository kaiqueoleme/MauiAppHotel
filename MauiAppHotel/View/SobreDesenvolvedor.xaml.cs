namespace MauiAppHotel.View;

public partial class SobreDesenvolvedor : ContentPage
{
	public SobreDesenvolvedor()
	{
		InitializeComponent();
	}

    
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}