using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Concursos {

        [Key] // chave primária
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // inibe a opção AutoNumber
        public int ID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(8)]
        [RegularExpression("[01]?[0-9]{2}/20[0-9]{2}", ErrorMessage = "O nome do concurso é do tipo nnn/aaaa, onde nnn é nº do concurso e aaaa o ano do concurso")]
        [Display(Name = "Concurso")]
        public string NomeConcurso { get; set; }

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