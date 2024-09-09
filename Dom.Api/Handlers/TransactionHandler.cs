using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Responses;
using Microsoft.EntityFrameworkCore;
using Dom.Lib.Requests.Transactions;
using Dom.Api.Data;

namespace Dom.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionReq request)
    {
        try
        {
            var transaction = new Transaction
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Amount = request.Amount,
                Title = request.Title,
                Type = request.Type,
                PaydAt = request.PaidAt
            };

            await context.Transactions.AddAsync(transaction);
            await context.SaveChangesAsync();

            return new Response<Transaction?>(transaction, 201, "Transaction successfully created");
        }
        catch
        {
            return new Response<Transaction?>(null, 500, "Something went wrong creating the new transaction");
        }
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionReq request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdReq request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodReq request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionReq request)
    {
        throw new NotImplementedException();
    }
}