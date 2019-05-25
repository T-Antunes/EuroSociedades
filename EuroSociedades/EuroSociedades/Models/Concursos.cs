using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Concursos {

        [Key] // chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // inibe a opção AutoNumber
        public string ID { get; set; }

        [Required]
        [DisplayName("Data do Concurso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataConcurso { get; set; }

        // *******************************************
        // especificação da chave forasteira
        // *******************************************

        // FK para a Chave (Sorteada)
        [ForeignKey("ChaveSorteada")]
        public int? ChaveFK { get; set; }
        public virtual Chaves ChaveSorteada { get; set; }
    }
}