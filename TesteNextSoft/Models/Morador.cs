using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNextSoft.Models
{
    public class Morador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Familia Familia { get; set; }
        public int FamiliaId { get; set; }

        public Morador()
        {
        }

        public Morador(int familiaId, string nome, int idade)
        {
            FamiliaId = familiaId;
            Nome = nome;
            Idade = idade;
        }
    }
}
