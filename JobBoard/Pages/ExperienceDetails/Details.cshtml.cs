using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.ExperienceDetails
{
    public class DetailsModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public DetailsModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        public Experience Experience { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Experience = await _context.Experience.FirstOrDefaultAsync(m => m.ExperienceId == id);

            if (Experience == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
