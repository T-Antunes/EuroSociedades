using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Pagamentos {

        [Key]
        public int ID { get; set; }  //pk

        //Descrição do Pagamento
        [Required]
        [DisplayName("Data de Pagamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPagamento { get; set; }

        [Required]
        [DisplayName("Valor Pago")]
        public decimal ValorPago { get; set; }

        // *******************************************
        // especificação das chaves forasteiras
        // *******************************************

        // FK para o Socio (Jogador x da Sociedade y)
        [DisplayName("Socio")]
        [ForeignKey("Jog_Soc")]
        public int Jog_SocFK { get; set; }

        public virtual Jog_Soc Jog_Soc { get; set; }
    }
}