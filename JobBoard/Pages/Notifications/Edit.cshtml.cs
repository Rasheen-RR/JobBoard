using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.Notifications
{
    public class EditModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public EditModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notification Notification { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification = await _context.Notification
                .Include(n => n.Candidate)
                .Include(n => n.Company).FirstOrDefaultAsync(m => m.NotificationId == id);

            if (Notification == null)
            {
                return NotFound();
            }
           ViewData["CandidateId"] = new SelectList(_context.Candidate, "CandidateId", "CandidateId");
           ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(Notification.NotificationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotificationExists(int id)
        {
            return _context.Notification.Any(e => e.NotificationId == id);
        }
    }
}
