using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutoringTracker.Data;
using TutoringTracker.Models;

namespace TutoringTracker.Pages;

public class CheckInModel : PageModel
{
    private readonly AppDbContext _context;

    public CheckInModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string StudentId { get; set; } = string.Empty;

    [BindProperty]
    public int SelectedCourseId { get; set; }

    [BindProperty]
    public string SelectedReason { get; set; } = string.Empty;

    public List<SelectListItem> CourseOptions { get; set; } = new();

    public List<string> Reasons { get; } =
        new() { "Exam prep", "Homework help", "Study skills", "Concept review", "Other" };

    public string? Message { get; set; }

    public async Task OnGetAsync()
    {
        await LoadCoursesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadCoursesAsync();

        if (string.IsNullOrWhiteSpace(StudentId) ||
            SelectedCourseId == 0 ||
            string.IsNullOrWhiteSpace(SelectedReason))
        {
            Message = "Please fill in all fields.";
            return Page();
        }

        var inputId = StudentId.Trim().ToUpper();
        
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.StudentId.ToUpper() == inputId);

        if (student == null)
        {
            Message = "Student ID not found.";
            return Page();
        }

        var visit = new Visit
        {
            StudentId = student.Id,
            CourseId = SelectedCourseId,
            Reason = SelectedReason,
            CheckInTime = DateTime.UtcNow
        };


        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();

        // Clear form + show success
        StudentId = string.Empty;
        SelectedCourseId = 0;
        SelectedReason = string.Empty;
        Message = "Check-in successful. Thank you!";

        return Page();
    }

    private async Task LoadCoursesAsync()
    {
        var courses = await _context.Courses
            .OrderBy(c => c.Code)
            .ToListAsync();

        CourseOptions = courses
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Code} - {c.Title}"
            })
            .ToList();
    }
}
