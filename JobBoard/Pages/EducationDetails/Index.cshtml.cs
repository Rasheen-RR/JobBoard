using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobBoard.Context;
using JobBoard.Models;

namespace JobBoard.Pages.EducationDetails
{
    public class IndexModel : PageModel
    {
        private readonly JobBoard.Context.JobBoardContext _context;

        public IndexModel(JobBoard.Context.JobBoardContext context)
        {
            _context = context;
        }

        public IList<Education> Education { get;set; }

        public async Task OnGetAsync()
        {
            Education = await _context.Education.ToListAsync();
        }
    }
}
