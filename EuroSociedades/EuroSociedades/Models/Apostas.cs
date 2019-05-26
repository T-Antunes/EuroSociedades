using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Apostas {

        public Apostas() {
            ListaChaves = new HashSet<Chaves>();
        }

        [Key]
        public int ID { get; set; }  //pk

        //Descrição da Aposta
        [Required]
        [DisplayName("Data do Registo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRegisto { get; set; }

        [Required]
        [DisplayName("Valor da Aposta")]
        public decimal ValorAposta { get; set; }

        [DisplayName("Valor do Prémio")]
        public decimal? ValorPremio { get; set; }

        // *******************************************
        // especificação das chaves forasteiras
        // *******************************************

        // FK para o Concurso
        [ForeignKey("Concurso")]
        public int ConcursoFK { get; set; }
        public virtual Concursos Concurso { get; set; }

        // FK para a Sociedade
        [ForeignKey("Sociedade")]
        public int SociedadeFK { get; set; }
        public virtual Sociedades Sociedade { get; set; }

        // Criar uma lista de Chaves
        // contidas na Aposta 
        public virtual ICollection<Chaves> ListaChaves { get; set; }
    }
}