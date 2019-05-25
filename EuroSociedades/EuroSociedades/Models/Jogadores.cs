using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EuroSociedades.Models {

    public class Jogadores {

        public Jogadores() {
            ListaSociedades = new HashSet<Jog_Soc>();
        }

        [Key]
        public int ID { get; set; }  //pk

        //Descrição do Jogador
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-ZÂÁÓÉÍ][a-záéíóúàèìòùâêîôûãõçäëöüïñ]+(( | e | de | da | das | do | d'|-)[A-ZÂÁÓÉÍ][a-záéíóúàèìòùâêîôûãõçäëöüïñ]+){1,3}",
           ErrorMessage = "O {0} só aceita letras. Cada nome deve começar por uma maiúscula seguida de minúsculas...")]
        [StringLength(40, ErrorMessage = "O {0} só aceita {1} carateres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Email { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        // Criar uma lista de Sociedades
        // às quais o Jogador pertence
        public ICollection<Jog_Soc> ListaSociedades { get; set; }

    }
}