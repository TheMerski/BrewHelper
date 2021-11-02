namespace BrewHelper.Web.Pages
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
#pragma warning disable SA1649
    public class ErrorModel : PageModel
#pragma warning restore SA1649
    {
        private readonly ILogger<ErrorModel> logger;

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

#pragma warning disable 8618
#pragma warning disable SA1201
        public ErrorModel(ILogger<ErrorModel> logger)
#pragma warning restore SA1201
#pragma warning restore 8618
        {
            this.logger = logger;
        }

        public void OnGet()
        {
            this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
        }
    }
}