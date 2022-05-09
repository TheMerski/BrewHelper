namespace BrewHelper.Web.Helpers
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;
    using Blazored.SessionStorage;
    using Fluxor.Persist.Storage;

    /// <summary>
    /// Used for saving fluxor states with persists.
    /// </summary>
    public class StateStorageProvider : IStringStateStorage
    {
        private readonly ISessionStorageService sessionStorageService;
        private readonly ILocalStorageService localStorageService;

        public StateStorageProvider(ISessionStorageService sessionStorageService, ILocalStorageService localStorageService)
        {
            this.sessionStorageService = sessionStorageService;
            this.localStorageService = localStorageService;
        }

        public async ValueTask<string> GetStateJsonAsync(string statename)
        {
            return await this.sessionStorageService.GetItemAsStringAsync(statename);
        }

        public async ValueTask StoreStateJsonAsync(string statename, string json)
        {
            await this.sessionStorageService.SetItemAsStringAsync(statename, json);
        }
    }
}