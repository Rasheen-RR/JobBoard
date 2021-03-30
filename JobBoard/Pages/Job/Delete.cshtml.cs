using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.Job
{
    public class DeleteModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public DeleteModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobPosting = await _context.JobPosting.FirstOrDefaultAsync(m => m.JobId == id);

            if (JobPosting == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobPosting = await _context.JobPosting.FindAsync(id);

            if (JobPosting != null)
            {
                _context.JobPosting.Remove(JobPosting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
