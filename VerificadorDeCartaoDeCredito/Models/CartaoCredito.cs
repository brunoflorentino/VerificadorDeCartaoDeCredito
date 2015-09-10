using System;
using System.ComponentModel.DataAnnotations;

namespace VerificadorDeCartaoDeCredito.Models
{
    public class CartaoCredito
    {
        [Display(Name = "Número do Cartão de Crédito")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Numero { get; set; }
    }
}