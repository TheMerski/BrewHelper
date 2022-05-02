using System.Threading.Tasks;
using BrewHelper.Web.Shared.Snackbar.Stores.Actions;
using Fluxor;
using MudBlazor;

namespace BrewHelper.Web.Shared.Snackbar.Stores.Effects;

public class SnackbarEffect
{
    private readonly ISnackbar snackbar;

    public SnackbarEffect(ISnackbar snackbar)
    {
        this.snackbar = snackbar;
    }

    [EffectMethod]
    public Task CreateSuccessSnackbar(SuccessMessageAction action, IDispatcher dispatcher)
    {
        this.snackbar.Add(action.Message, Severity.Success);
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task CreateErrorSnackbar(ErrorMessageAction action, IDispatcher dispatcher)
    {
        this.snackbar.Add($"Something went wrong: {action.Error.Message}", Severity.Error);
        return Task.CompletedTask;
    }
}
