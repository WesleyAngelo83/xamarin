using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Servico.Modelo;
using App01_ConsultarCep.Servico;

namespace App01_ConsultarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender,EventArgs args)
        {
            string cep = CEP.Text.Trim();

            //Validacoes
            if (ValidaCEP(cep))
            {

                try
                {

                    //ViaCEp Servico            
                    Endereco end = viaCEPServico.BuscarEnderecoViaCep(cep);
                    RESULTADO.Text = string.Format("Endereço:{2} de {3} {0},{1} {2}", end.localidade, end.uf, end.logradouro, end.complemento);
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro", e.Message, "OK");
                }

            }            
            
        }

        private bool ValidaCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro","CEP Inválido - O Cep deve conter 8 caracteres!","OK");
                valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep,out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido - O Cep deve conter apenas números!", "OK");
                valido = false;
            }
            return valido;
        }

    }
}
