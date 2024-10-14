using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Requests.Account;

public class SignUpReq : Request
{
    [Required(ErrorMessage = "Obrigatório preenchimento de um e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Obrigatório preenchimento de uma senha")]
    public string Password { get; set; } = string.Empty;
}
