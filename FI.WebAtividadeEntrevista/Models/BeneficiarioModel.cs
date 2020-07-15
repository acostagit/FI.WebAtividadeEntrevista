using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [RegularExpression(@"[0-9]{11}", ErrorMessage = "CPF inválido. O CPF deve conter 11 caracteres e apenas dígitos")]
        public string CPF { get; set; }

        public long IdCliente { get; set; }

    }
}