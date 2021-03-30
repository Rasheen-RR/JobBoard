using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.Notifications
{
    public class DetailsModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public DetailsModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
