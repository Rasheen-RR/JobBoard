using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class JobApplication
    {
        [Key]
        public Guid JobApplicationId { get; set; }
        public Guid JobId { get; set; }
        public JobPosting jobPosting { get; set; }
        public Guid applicantId { get; set; }
        public Candidate candidate { get; set; }

    }
}
