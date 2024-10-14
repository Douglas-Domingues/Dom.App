using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Requests.Account;

public class SignUpReq : Request
{
    [Required(ErrorMessage = "E-mail required")]
    [EmailAddress(ErrorMessage = "Invalid E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-mail required")]
    public string Password { get; set; } = string.Empty;
}
