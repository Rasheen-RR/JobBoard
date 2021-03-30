using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.Notifications
{
    public class CreateModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public CreateModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CandidateId"] = new SelectList(_context.Candidate, "CandidateId", "CandidateId");
        ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId");
            return Page();
        }

        [BindProperty]
        public Notification Notification { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notification.Add(Notification);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
