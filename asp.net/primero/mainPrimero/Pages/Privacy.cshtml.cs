using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace mainPrimero.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string fecha = DateTime.Now.ToString("d", new CultureInfo("es-CR"));
            ViewData["TimeStamp"]= fecha;

        }
    }

}
