using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Requests.Transactions;

public class DeleteTransactionReq : Request
{
    public long Id { get; set; }
}
