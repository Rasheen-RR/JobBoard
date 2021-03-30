using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.JobApplications
{
    public class DetailsModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public DetailsModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        public JobApplication JobApplication { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobApplication = await _context.JobApplication.FirstOrDefaultAsync(m => m.JobApplicationId == id);

            if (JobApplication == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
