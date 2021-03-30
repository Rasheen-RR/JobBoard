using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class SavedSearch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaveId { get; set; }
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public Guid JobId { get; set; }
        public JobPosting job { get; set; }
    }
}
