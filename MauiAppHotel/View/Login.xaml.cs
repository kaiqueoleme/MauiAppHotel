using MauiAppHotel.Models;

namespace MauiAppHotel.View;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new SobreDesenvolvedor());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            List<DadosUsuario> lista_usuario = new List<DadosUsuario>
            {
                new DadosUsuario()
                {
                    Usuario = "Leme",
                    Senha = "123"
                },
                new DadosUsuario
                {
                    Usuario = "Oliveira",
                    Senha = "321"
                }
            };

            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txt_user.Text,
                Senha = txt_password.Text
            };

            if (lista_usuario.Any(i=> dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha))
            {
                SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

                Navigation.PushAsync(new View.ContratacaoHospedagem());
            } else
            {
                throw new Exception("Usuário ou senha incorretos.");
            }


        } catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}