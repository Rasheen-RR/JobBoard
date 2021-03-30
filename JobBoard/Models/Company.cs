using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Models
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public String password { get; set; }
    }
}