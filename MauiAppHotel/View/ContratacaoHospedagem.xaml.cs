using MauiAppHotel.Models;

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


    

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem()
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpk_checknin.Date,
                DataCheckOut = dtpk_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });

        } catch (Exception ex) {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void dtpk_checknin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpk_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpk_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Sair do App?", "Sim", "Não");

        if (confirmacao)
        {
            SecureStorage.Default.Remove("usuario_logado");

            await Navigation.PopToRootAsync();
        }
    }
}