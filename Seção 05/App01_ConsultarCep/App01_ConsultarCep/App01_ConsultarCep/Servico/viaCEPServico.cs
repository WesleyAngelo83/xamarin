﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCep.Servico
{
    public class viaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep (string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo) ;

        return end;
        }

    }
}
