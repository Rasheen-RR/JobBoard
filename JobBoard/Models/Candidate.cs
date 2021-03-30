using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Candidate
    {
        [Key]
        public Guid CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public String password { get; set; }
        public bool IsActive { get; set; }
        public Guid ResumeId { get; set; }
        public Resume resume { get; set; }

    }
}
