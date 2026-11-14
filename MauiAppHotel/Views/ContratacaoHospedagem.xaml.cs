using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {

        new Quarto { Nome= "Suíte Master", ValorAdultos = 225.5, ValorCriancas = 200 },
        new Quarto { Nome= "Suíte Premium", ValorAdultos = 180.30, ValorCriancas = 110.30},
        new Quarto { Nome= "Suíte Viajante", ValorAdultos = 140, ValorCriancas = 75 },
        new Quarto { Nome= "Suíte Crise", ValorAdultos = 100.3, ValorCriancas = 50.0 }
    };
    public ContratacaoHospedagem()
    {
        InitializeComponent();
        pck_quarto.ItemsSource = lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(3);

        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(4);
    }
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = e.NewDate?.AddDays(1);
    }
    private void btn_Calculo(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new()
            {
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                QuartoEscolhido = (Quarto)pck_quarto.SelectedItem,
                DataCheckin = dtpck_checkin.Date.Value,
                DataCheckout = dtpck_checkout.Date.Value,
            };
            Navigation.PushAsync(new HospedagemContratada
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops!", ex.Message, "OK");
        } 
    }

        private void btn_Sobre(object sender, EventArgs e) 
        {      
        Navigation.PushAsync(new Sobre());
        }
}
