using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Chaves {

        [Key]
        public int ID { get; set; }

        //Descrição da Chave

        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Numeros { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Estrelas { get; set; }

        // *******************************************
        // especificação da chave forasteira
        // *******************************************

        // FK para o Tipo de Chave
        [Required]
        [ForeignKey("TipoChave")]
        public int TipoChaveFK { get; set; }
        public virtual TipoChaves TipoChave { get; set; }
    }
}