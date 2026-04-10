using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rekonstrukce.Pages;

public sealed class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true, Name = "kultura")]
    public string? Kultura { get; set; }

    public string AktualniKultura =>
        string.IsNullOrWhiteSpace(Kultura) ? "cs" : Kultura.ToLowerInvariant();

    public IActionResult OnGet()
    {
        if (AktualniKultura is not ("cs" or "uk" or "en" or "de"))
        {
            return Redirect("/cs");
        }

        return Page();
    }
}
