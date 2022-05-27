using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNextSoft.Models;

namespace TesteNextSoft.Data
{
    public class SeedingService
    {
        private TesteNextSoftContext _context;

        public SeedingService(TesteNextSoftContext context)
        {
            _context = context;
        }

        /*public void Seed()
        {
            if (_context.Condominio.Any() ||
                _context.Familia.Any() ||
                _context.Morador.Any())
            {
                return;
            }

            Condominio c1 = new Condominio("Serra Negra", "Vila Nova");
            Condominio c2 = new Condominio("Casa Branca", "Moema");
            Condominio c3 = new Condominio("Bom Recanto", "Vila Guarani");
            Condominio c4 = new Condominio("Imaré", "Capuava");
            Condominio c5 = new Condominio("Andorinha", "Jardim América");

            Familia f1 = new Familia("Silva", 2, 10);
            Familia f2 = new Familia("Novaes", 2, 45);
            Familia f3 = new Familia("Nobrega", 4, 110);
            Familia f4 = new Familia("Campineli ", 1, 712);
            Familia f5 = new Familia("Souza", 1, 715);
            Familia f6 = new Familia("Gonçalvez", 3, 640);
            Familia f7 = new Familia("Camargo", 3, 301);
            Familia f8 = new Familia("Brito", 5, 507);
            Familia f9 = new Familia("Oliveira", 3, 530);
            Familia f10 = new Familia("Jovanelli ", 4, 507);
            Familia f11 = new Familia("Vieira", 5, 310);

            


            _context.Condominio.AddRange(c1, c2, c3, c4, c5);

            _context.Familia.AddRange(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11);

            _context.SaveChanges();

        }*/

    }
}
