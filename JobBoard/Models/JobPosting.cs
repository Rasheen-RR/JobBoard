using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class JobPosting
    {

        [Key]
        public Guid JobId { get; set; }
        public Company company { get; set; }
        public String Title { get; set; }
        public String JobFunction { get; set; }
        public String Description { get; set; }
        public String Requirement { get; set; }
        public String Responsibilities { get; set; }
        public String Qualifications { get; set; }
        public String Skills { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsPublic { get; set; }
        public Boolean IsDraft { get; set; }
        public Guid OwnerId { get; set; }

    }
}
