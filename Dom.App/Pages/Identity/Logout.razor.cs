using Dom.App.Security;
using Dom.Lib.Handlers;
using Dom.Lib.Requests.Account;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dom.App.Pages.Identity;

public partial class LogoutPage : ComponentBase
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

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        if (await AuthenticationStateProvider.CheckAuthAsync())
        {
            await AccountHandler.LogoutAsync(); // realiza o logout
            await AuthenticationStateProvider.GetAuthenticationStateAsync(); // busca o estado de autenticação
            AuthenticationStateProvider.NotifyAuthenticationStateChanged(); // notifica a aplicação da mudança de estado
        }

        await base.OnInitializedAsync(); // continua qualquer outro fluxo do app
    }

    #endregion

}
