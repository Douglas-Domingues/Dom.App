using Dom.Lib.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Dom.App.Security;

public class CookieAuthenticationStateProvider(IHttpClientFactory clientFactory) : AuthenticationStateProvider, ICookieAuthenticationStateProvider
{
    private bool _isAuthenticated = false;
    private readonly HttpClient _client = clientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<bool> CheckAuthAsync()
    {
        await GetAuthenticationStateAsync();
        return _isAuthenticated;
    }

    public void NotifyAuthenticationStateChanged() =>
    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _isAuthenticated = false;

        var user = new ClaimsPrincipal(new ClaimsIdentity());

        var userInfo = await GetUser();
        if (userInfo is null)
            return new AuthenticationState(user);

        var claims = await GetClaims(userInfo);

        var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
        user = new ClaimsPrincipal(id);

        _isAuthenticated = true;
        return new AuthenticationState(user);
    }

    private async Task<User?> GetUser()
    {
        try
        {
            return await _client.GetFromJsonAsync<User?>("v1/identity/manage/info");
        }
        catch
        {
            return null;
        }
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email), //claims tem nomes específicos - é possível buscar do user.identity.claims
            new Claim(ClaimTypes.Email, user.Email)

        };

        claims.AddRange(
            user.Claims.Where(x =>
            x.Key != ClaimTypes.Name &&
            x.Key != ClaimTypes.Email).
        Select(x => new Claim(x.Key, x.Value)));

        RoleClaim[]? roles = null;

        try
        {
            roles = await _client.GetFromJsonAsync<RoleClaim[]>("v1/identity/roles");
        }
        catch
        {
            return claims;
        }

        foreach(var role in roles ?? [])
        {
            if(!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value))
            {
                claims.Add(new Claim(role.Type, role.Value, role.ValueType, role.Issuer, role.OriginalIssuer));
            }
        }
        // outra maneira de escrever esse trecho.
        // claims.AddRange(from role in roles ?? [] where !string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value) select new Claim(role.Type, role.Value, role.ValueType, role.Issuer, role.OriginalIssuer));

        return claims;
    }

}
