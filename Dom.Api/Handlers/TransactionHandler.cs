using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Responses;
using Microsoft.EntityFrameworkCore;
using Dom.Lib.Requests.Transactions;
using Dom.Api.Data;
using Dom.Lib.Common.Extensions;

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
                Description = request.Description,
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
        try
        {
            var transaction = await context.Transactions.FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);

            if (transaction == null)
                return new Response<Transaction?>(null, 404, "No results for this Id");

            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();

            return new Response<Transaction?>(transaction, message: "Transaction successfully removed");                
        }
        catch
        {
            return new Response<Transaction?>(null, 500, "Something went wrong removing the transaction");
        }
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdReq request)
    {
        try
        {
            var transaction = await context.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);

            return (transaction == null)
                ? new Response<Transaction?>(null, 404, "No results for this Id")
                : new Response<Transaction?>(transaction);
        }
        catch
        {
            return new Response<Transaction?>(null, 500, "Something went wrong retrieving the transaction");
        }
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodReq request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirstDay();
            request.EndDate ??= DateTime.Now.GetLastDay();
        }
        catch
        {

            return new PagedResponse<List<Transaction>?>(null, 500, "Something went wrong handling StartDate or EndDate provided");
        }

        try
        {
            var query = context.Transactions
            .AsNoTracking()
            .Where(t =>
                t.CreatedAt >= request.StartDate &&
                t.CreatedAt <= request.EndDate &&
                t.UserId == request.UserId)
            .OrderBy(t => t.Id);

            var transactions = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Transaction>?>(
                transactions, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Transaction>?>(null, 500, "Something went wrong retrieving the results");
        }

    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionReq request)
    {
        try
        {
            var transaction = await context.Transactions
            .FirstOrDefaultAsync(t => t.Id == request.Id && t.UserId == request.UserId);

            if (transaction == null)
                return new Response<Transaction?>(null, 404, "No results for this Id");

            transaction.CategoryId = request.CategoryId;
            transaction.Title = request.Title;
            transaction.Description = request.Description;
            transaction.Amount = request.Amount;
            transaction.PaydAt= request.PaydAt;
            transaction.Type = request.Type;

            context.Update(transaction);
            await context.SaveChangesAsync();
            
            return new Response<Transaction?>(transaction, message: "Transaction successfully updated");
        }
        catch
        {
            return new Response<Transaction?>(null, 500, "Something went wrong updating the transaction");
        }
    }
}