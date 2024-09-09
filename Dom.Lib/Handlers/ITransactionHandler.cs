using Dom.Lib.Requests.Transactions;
using Dom.Lib.Responses;
using Dom.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Handlers;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> CreateAsync(CreateTransactionReq request);
    Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdReq request);
    Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodReq request);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionReq request);
    Task<Response<Transaction?>> DeleteAsync(DeleteTransactionReq request);
}
