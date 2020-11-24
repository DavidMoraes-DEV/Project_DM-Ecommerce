using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /* namespace para utilizar o Annotations "[Require]" abaixo */

namespace Ecommercee.Models
{
    public class Contato
    {
        /* Regras de Validação aplicadas as propriedade da classe Contato */
        [Required] /* Faz uma verificação automaticamente da propriedade abaixo, sendo que "Required" torna obrigatório informar esse dado para que seja possível enviar o formulário com sucesso */
        [MinLength(3)] /* Especifica a quantidade mínima de caracteres necessários para um nome válido */
        public string Nome { get; set; }
        [Required]
        [EmailAddress] /* Verifica e valida as regras de um email válido no email fornecido no formulário */
        public string Email { get; set; }
        [Required]
        [MinLength(10)] /* Quantidade mínima de caracter para o texto */
        [MaxLength(1000)] /* Quantidade máxima de caracter para o texto */
        public string Texto { get; set; }
    }
}
