using Dom.Lib.Requests.Account;
using Dom.Lib.Responses;

namespace Dom.Lib.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> SignInAsync(SignInReq request);
    Task<Response<string>> SignUpAsync(SignUpReq request);
    Task LogoutAsync();
}
