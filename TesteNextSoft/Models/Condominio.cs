using System;
using System.Collections.Generic;


namespace TesteNextSoft.Models
{
    public class Condominio
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public double AreaTotalCondominio { get; set; }
        public double ValorIptu { get; set; }

        public Condominio()
        {

        }

        public Condominio(string nome, string bairro, double areaTotalCondominio, double valorDoIptu)
        {
            Nome = nome;
            Bairro = bairro;
            AreaTotalCondominio = areaTotalCondominio;
            ValorIptu = valorDoIptu;
        }
    }
}
