using System;
using AppConsultaCep.Model;
using AppConsultaCep.Service;
using Xamarin.Forms;

namespace AppConsultaCep
{
    public partial class AppConsultaCepPage : ContentPage
    {
        public AppConsultaCepPage()
        {
            InitializeComponent();

            BUTTON.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            Address address = ViaCepService.SearchAddressToCep(cep);

            RESULT.Text = String.Format("Endereço: {3}, {0}, {1}, {2}", 
                                        address.Localidade, address.Uf, address.Logradouro, address.Bairro);
        }
    }
}
