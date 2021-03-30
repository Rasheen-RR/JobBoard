using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.User
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
        ViewData["ResumeId"] = new SelectList(_context.Resume, "ResumeId", "ResumeId");
            return Page();
        }

        [BindProperty]
        public Candidate Candidate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candidate.Add(Candidate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
