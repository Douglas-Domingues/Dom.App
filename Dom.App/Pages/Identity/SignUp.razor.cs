using Dom.Lib.Handlers;
using Dom.Lib.Requests.Account;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Dom.App.Pages.Identity;

public partial class SignUpPage : ComponentBase
{
    #region Dependencies

    [Inject]
    public ISnackbar SnackBar { get; set; } = null!;
    [Inject]
    public IAccountHandler AccountHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    #endregion

    #region Properties

    public SignUpReq InputModel { get; set; } = new();
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
            var result = await AccountHandler.SignUpAsync(InputModel);

            if(result.IsSuccess)
            {
                SnackBar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/login");
            }
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
