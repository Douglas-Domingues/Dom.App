using Dom.Lib.Handlers;
using Dom.Lib.Requests;
using Dom.Lib.Requests.Account;
using Dom.Lib.Responses;
using System.Net.Http.Json;
using System.Text;

namespace Dom.App.Handler
{
    public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

        public async Task<Response<string>> SignInAsync(SignInReq request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/login?UseCookies=true", request);

            return result.IsSuccessStatusCode
                ? new Response<string>(null, 200, "Successfully logged in")
                : new Response<string>(null, (int)result.StatusCode, "Something went wrong trying to log in");
        }

        public async Task<Response<string>> SignUpAsync(SignUpReq request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/register", request);

            return result.IsSuccessStatusCode
                ? new Response<string>(null, 200, "Successfull signed up")
                : new Response<string>(null, (int)result.StatusCode, "Something went wrong trying to register the new user");
        }
        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("v1/identity/logout", emptyContent);
        }
    }
}
