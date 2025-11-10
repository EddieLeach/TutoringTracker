using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutoringTracker.Data;

namespace TutoringTracker.Pages;

public class AdminModel : PageModel
{
    private readonly AppDbContext _context;

    // Use the same cookie name defined in AdminLoginModel
    private const string AdminCookieName = AdminLoginModel.AdminCookieName;

    public int TotalVisits { get; set; }
    public Dictionary<string, int> VisitsByCourse { get; set; } = new();
    public Dictionary<string, int> VisitsByReason { get; set; } = new();
    public List<VisitRow> Visits { get; set; } = new();

    public AdminModel(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        // 🔐 1) Require admin cookie
        if (!Request.Cookies.TryGetValue(AdminCookieName, out var val) || val != "true")
        {
            // Not logged in -> go to AdminLogin
            return RedirectToPage("/AdminLogin");
        }

        // ✅ 2) Load all visits for the dashboard
        var visitList = await _context.Visits
            .Include(v => v.Student)
            .Include(v => v.Course)
            .OrderByDescending(v => v.CheckInTime)
            .ToListAsync();

        TotalVisits = visitList.Count;

        Visits = visitList.Select(v => new VisitRow
        {
            Time = v.CheckInTime,
            Student = $"{v.Student.StudentId} - {v.Student.Name}",
            Course = v.Course.Code,
            Reason = v.Reason
        }).ToList();

        VisitsByCourse = visitList
            .GroupBy(v => v.Course.Code)
            .ToDictionary(g => g.Key, g => g.Count());

        VisitsByReason = visitList
            .GroupBy(v => v.Reason)
            .ToDictionary(g => g.Key, g => g.Count());

        return Page();
    }

    public async Task<IActionResult> OnGetExportAsync()
    {
        // Require admin cookie
        if (!Request.Cookies.TryGetValue(AdminCookieName, out var val) || val != "true")
        {
            return RedirectToPage("/AdminLogin");
        }

        var visits = await _context.Visits
            .Include(v => v.Student)
            .Include(v => v.Course)
            .OrderByDescending(v => v.CheckInTime)
            .ToListAsync();

        var lines = new List<string>
        {
            "Time,StudentId,StudentName,CourseCode,Reason"
        };

        lines.AddRange(visits.Select(v =>
            $"{v.CheckInTime:u},{v.Student.StudentId},\"{v.Student.Name}\",{v.Course.Code},\"{v.Reason}\""));

        var csv = string.Join(Environment.NewLine, lines);
        var bytes = System.Text.Encoding.UTF8.GetBytes(csv);

        return File(bytes, "text/csv", "math-lab-visits.csv");
    }

    public IActionResult OnGetLogout()
    {
        // Remove the admin cookie
        Response.Cookies.Delete(AdminCookieName);

        // Redirect back to login page
        return RedirectToPage("/AdminLogin");
    }


    public class VisitRow
    {
        public DateTime Time { get; set; }
        public string Student { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
