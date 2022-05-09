using System;

namespace BrewHelper.Web.Shared.Snackbar.Stores.Actions;

public record ErrorMessageAction(Exception Error);