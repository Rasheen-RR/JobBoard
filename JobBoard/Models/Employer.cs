using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Employer
    {
        [Key]
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool isActive { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public List<JobPosting> JobPost { get; set; }

    }
}
