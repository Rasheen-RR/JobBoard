using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.Job
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
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobPosting.Add(JobPosting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
