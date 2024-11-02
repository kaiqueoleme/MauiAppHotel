namespace MauiAppHotel.View;

public partial class ContratacaoHospedagem : ContentPage
{

    App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpk_checknin.MinimumDate = DateTime.Now;
        dtpk_checknin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpk_checkout.MinimumDate = dtpk_checknin.Date.AddDays(1);
        dtpk_checkout.MaximumDate = dtpk_checknin.Date.AddMonths(6);
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new SobreDesenvolvedor());

        } catch (Exception ex) 
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
        

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
         try {

            Navigation.PushAsync(new HospedagemContratada());

        } catch (Exception ex) {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void dtpk_checknin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpk_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpk_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}