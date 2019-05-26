using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EuroSociedades.Models {

    public class EurosociDB : DbContext {

        public EurosociDB() : base("EuroSociDBConnectionString") { }


        // definir as tabelas
        public virtual DbSet<Jogadores> Jogadores { get; set; } // tabela Jogadores
        public virtual DbSet<Sociedades> Sociedades { get; set; } // tabela Sociedades
        public virtual DbSet<Jog_Soc> Jog_Socs { get; set; } // tabela Sócios
        public virtual DbSet<Concursos> Concursos { get; set; } // tabela Concursos
        public virtual DbSet<Apostas> Apostas { get; set; } // tabela Apostas
        public virtual DbSet<Chaves> Chaves { get; set; } // tabela Chaves
        public virtual DbSet<Pagamentos> Pagamentos { get; set; } // tabela Pagamentos
        public virtual DbSet<TipoChaves> TipoChaves { get; set; } // tabela TipoChaves



        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}