using Dom.App.Security;
using Dom.Lib.Handlers;
using Dom.Lib.Requests.Account;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dom.App.Pages.Identity;

public partial class LoginPage : ComponentBase
{

    #region Dependencies

    [Inject]
    public ISnackbar SnackBar { get; set; } = null!;
    [Inject]
    public IAccountHandler AccountHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion

    #region Properties

    public SignInReq InputModel { get; set; } = new();
    public bool IsBusy { get; set; } = false;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        var authstate = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authstate.User;

        if (user.Identity is { IsAuthenticated: true }) // = user.identity is not null && user.identity.IsAuthenticated == true
        {
            NavigationManager.NavigateTo("/");
        }
    }

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await AccountHandler.SignInAsync(InputModel);

            if (result.IsSuccess)
            {
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                NavigationManager.NavigateTo("/");
            }
            else
                SnackBar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            SnackBar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion
}
