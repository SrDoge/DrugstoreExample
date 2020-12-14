using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DrugstoreExemple.Entities
{
    public class Produto
    {
        [Key]
        [Display(Name = "Id")]
        public int ProdID { get; set; }
        
        [Required]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Display(Name = "Breve Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preco do Produto")]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Preco { get; set; }
        
        [Required]
        [Display(Name = "Quantidade do Produto no estoque")]
        public int Qtde { get; set; }
    }
}
