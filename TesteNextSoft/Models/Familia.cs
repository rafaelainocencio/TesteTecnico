using System;
using System.ComponentModel.DataAnnotations;

namespace TesteNextSoft.Models
{
    public class Familia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Condominio Condominio { get; set; }
        [Display(Name = "Condomínio")]
        public int CondominioId { get; set; }
        public int Apto { get; set; }
        [Display(Name = "Área do Apartamento")]
        public double AreaApto { get; set; }
        [Display(Name = "Fração ideal")]
        public double FracaoIdeal { get; set; }
        [Display(Name = "Valor do IPTU")]
        public double ValorIptuProporcional { get; set; }


        public Familia()
        {
        }

        public Familia(int id, string nome, int condominioId, int apto, double areaApto, double fracaoIdeal, double valorIptuProporcional)
        {
            Id = id;
            Nome = nome;
            CondominioId = condominioId;
            Apto = apto;
            AreaApto = areaApto;
            FracaoIdeal = fracaoIdeal;
            ValorIptuProporcional = valorIptuProporcional;
        }

        public double CalcularFracaoApartamento(double areaTotalCondominio)
        {
            FracaoIdeal = (AreaApto * 100) / areaTotalCondominio;
            return FracaoIdeal;
        }
        public double CalcularIptuApartamento(double valorIptu)
        {
            return (valorIptu * FracaoIdeal) / 100;
        }
    }
}
