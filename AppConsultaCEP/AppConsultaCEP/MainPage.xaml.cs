using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppConsultaCEP.Servico.Modelo;
using AppConsultaCEP.Servico;

namespace AppConsultaCEP
{
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            if (validaCEP(TXTCEP.Text.Trim()))
            {
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(TXTCEP.Text.Trim());

                RESULTADO.Text = string.Format("Endereço: {0},{1} {2}", end.Localidade, end.Uf, end.Logradouro);
            }

          
           
        }

        private bool validaCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido", "OK");

                valido = false;
            }

            return valido;
        }

    }
}
