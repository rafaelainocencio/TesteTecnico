using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNextSoft.Data;
using TesteNextSoft.Models;

namespace TesteNextSoft.Services
{
    public class FamiliaService
    {
        private readonly TesteNextSoftContext _context;


        public FamiliaService(TesteNextSoftContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Familia obj)
        {
            Familia familia = new Familia(obj.Id, obj.Nome, obj.CondominioId, obj.Apto, obj.AreaApto, obj.FracaoIdeal, obj.ValorIptuProporcional);

            familia.FracaoIdeal = familia.CalcularFracaoApartamento(_context.Condominio.Find(familia.CondominioId).AreaTotalCondominio);
            familia.ValorIptuProporcional = familia.CalcularIptuApartamento(_context.Condominio.Find(familia.CondominioId).ValorIptu);

            _context.Add(familia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Familia obj)
        {
            Familia familia = new Familia(obj.Id, obj.Nome, obj.CondominioId, obj.Apto, obj.AreaApto,obj.FracaoIdeal, obj.ValorIptuProporcional);

            familia.FracaoIdeal = familia.CalcularFracaoApartamento(_context.Condominio.Find(familia.CondominioId).AreaTotalCondominio);
            familia.ValorIptuProporcional = familia.CalcularIptuApartamento(_context.Condominio.Find(familia.CondominioId).ValorIptu);
            _context.Update(familia);
            await _context.SaveChangesAsync();
        }
    }
}
