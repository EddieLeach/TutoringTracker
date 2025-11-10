using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TutoringTracker.Pages;

public class AdminLoginModel : PageModel
{
    public const string AdminCookieName = "MathLabAdmin";
    private const string AdminCode = "MathLab2025"; // change this if you like

    [BindProperty]
    public string AccessCode { get; set; } = string.Empty;

    public string? Message { get; set; }

    public IActionResult OnGet()
    {
        // If already logged in, go straight to dashboard
        if (Request.Cookies.TryGetValue(AdminCookieName, out var val) && val == "true")
        {
            return RedirectToPage("/Admin");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (AccessCode == AdminCode)
        {
            Response.Cookies.Append(AdminCookieName, "true",
                new CookieOptions { HttpOnly = true, IsEssential = true });

            return RedirectToPage("/Admin");
        }

        Message = "Invalid access code.";
        return Page();
    }
}
