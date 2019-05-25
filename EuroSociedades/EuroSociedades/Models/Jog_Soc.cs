using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroSociedades.Models {

    public class Jog_Soc {

        public Jog_Soc() {

            ListaPagamentos = new List<Pagamentos>();
        }

        [Key]
        public int ID { get; set; }  //pk

        //dados do relacionamento entre Jogadores e Sociedades
        [Required]
        [DisplayName("Data de Entrada")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrada { get; set; }

        [DisplayName("Data de Saída")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataSaida { get; set; }

        // *******************************************
        // especificação das chaves forasteiras
        // *******************************************

        // FK para o Jogador
        [DisplayName("Jogador")]
        [ForeignKey("Jogador")]
        public int JogadorFK { get; set; }
        public virtual Jogadores Jogador { get; set; }

        // FK para a Sociedade
        [DisplayName("Sociedade")]
        [ForeignKey("Sociedade")]
        public int SociedadeFK { get; set; }
        public virtual Sociedades Sociedade { get; set; }

        public virtual List<Pagamentos> ListaPagamentos { get; set; }

    }
}