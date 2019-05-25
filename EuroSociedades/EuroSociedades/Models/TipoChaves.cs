using System.ComponentModel.DataAnnotations;

namespace EuroSociedades.Models {

    public class TipoChaves {

        [Key]
        public int ID { get; set; }  //pk

        //Descrição do Tipo de Chave
        [Required]
        [StringLength(20)]
        public string Tipo { get; set; }
    }
}