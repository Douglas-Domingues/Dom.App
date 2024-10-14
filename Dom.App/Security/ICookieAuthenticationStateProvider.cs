using Microsoft.AspNetCore.Components.Authorization;

namespace Dom.App.Security;

public interface ICookieAuthenticationStateProvider
{
    Task<bool> CheckAuthAsync();
    Task<AuthenticationState> GetAuthenticationStateAsync();
    void NotifyAuthenticationStateChanged();

}

public class CookieAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}
