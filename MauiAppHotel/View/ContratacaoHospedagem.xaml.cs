namespace MauiAppHotel.View;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();
        
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobreDesenvolvedor());

    }
}