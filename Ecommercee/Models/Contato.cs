using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommercee.Libraries.Lang;
using System.ComponentModel.DataAnnotations; /* namespace para utilizar o Annotations "[Require]" abaixo */

namespace Ecommercee.Models
{
    public class Contato
    {
        /* Regras de Validação aplicadas as propriedade da classe Contato, as mensagem de erros "MSG_E001, ...", vem do "Arquivo de Recursos" nomeado como: Message.resx */
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")] /* Faz uma verificação automaticamente da propriedade abaixo, sendo que "Required" torna obrigatório informar esse dado para que seja possível enviar o formulário com sucesso */
        [MinLength(3, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")] /* Especifica a quantidade mínima de caracteres necessários para um nome válido */
        public string Nome { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")] /* Verifica e valida as regras de um email válido no email fornecido no formulário */
        public string Email { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(10, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")] /* Quantidade mínima de caracter para o texto */
        [MaxLength(1000, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E003")] /* Quantidade máxima de caracter para o texto */
        public string Texto { get; set; }
    }
}
