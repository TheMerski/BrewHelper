using System.Threading.Tasks;
using BrewHelper.Authentication.DTO;
using Microsoft.AspNetCore.Components;

namespace BrewHelper.Web
{
    public partial class App
    {
        [Parameter]
        public InitialApplicationState? InitialState { get; set; }
        
        [Inject]
        private TokenProvider TokenProvider { get; set; } = fr

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (InitialState != null)
            {
                TokenProvider.XsrfToken = InitialState.XsrfToken;
            }
        }
    }
}