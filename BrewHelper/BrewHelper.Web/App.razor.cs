namespace BrewHelper.Web
{
    using BrewHelper.Authentication.DTO;
    using Microsoft.AspNetCore.Components;

    public partial class App
    {
        [Parameter]
        public InitialApplicationState? InitialState { get; set; }

        [Inject]
        private TokenProvider TokenProvider { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (this.InitialState != null)
            {
                this.TokenProvider.XsrfToken = this.InitialState.XsrfToken;
            }
        }
    }
}