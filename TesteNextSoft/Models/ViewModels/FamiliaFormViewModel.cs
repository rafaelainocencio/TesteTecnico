using System;
using System.Collections.Generic;

namespace TesteNextSoft.Models.ViewModels
{
    public class FamiliaFormViewModel
    {
        public Familia Familia { get; set; }
        public ICollection<Condominio> Condominios { get; set; }
    }
}
