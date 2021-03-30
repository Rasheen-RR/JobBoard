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
    public class IndexModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public IndexModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        public IList<JobApplication> JobApplication { get;set; }

        public async Task OnGetAsync()
        {
            JobApplication = await _context.JobApplication.ToListAsync();
        }
    }
}
