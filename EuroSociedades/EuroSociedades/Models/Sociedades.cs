using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Sociedades {

        public Sociedades() {
            ListaJogadores = new HashSet<Jog_Soc>();
        }

        [Key]
        public int ID { get; set; }  //pk

        //Descrição da Sociedade
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-Za-z0-9áéíóúàèìòùâêîôûãõçäëöüïñ -]+")]
        [StringLength(40, ErrorMessage = "O {0} só aceita {1} carateres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [DisplayName("Data de Constituição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataConstituicao { get; set; }

        public virtual ICollection<Jog_Soc> ListaJogadores { get; set; }

        // *******************************************
        // especificação da chave forasteira
        // *******************************************

        // FK para o Gestor
        [DisplayName("Gestor")]
        [ForeignKey("Gestor")]
        public int GestorFK { get; set; }
        public virtual Jogadores Gestor { get; set; }
    }
}