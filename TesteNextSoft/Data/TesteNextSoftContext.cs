using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteNextSoft.Models;

namespace TesteNextSoft.Data
{
    public class TesteNextSoftContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TesteNextSoftContext"));
        }

        public DbSet<TesteNextSoft.Models.Condominio> Condominio { get; set; }

        public DbSet<TesteNextSoft.Models.Familia> Familia { get; set; }

        public DbSet<TesteNextSoft.Models.Morador> Morador { get; set; }
    }
}
