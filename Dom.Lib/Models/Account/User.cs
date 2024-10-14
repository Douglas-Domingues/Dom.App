using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Models.Account;

public class User
{
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; } = false;
    public Dictionary<string, string> Claims { get; set; } = [];

    //preencher depois informações relevantes desde que estejam sendo retornadas no info
}
