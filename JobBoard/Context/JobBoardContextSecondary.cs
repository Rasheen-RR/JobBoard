using JobBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Context
{
    public class JobBoardContext : DbContext
    {

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<JobApplication> JobApplication { get; set; }
        public DbSet<JobPosting> JobPosting { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<SavedSearch> SavedSearch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JobBoard");
        }

        public JobBoardContext(
           Microsoft.EntityFrameworkCore.DbContextOptions<JobBoardContext> options)
           : base(options)
        {
        }
    }
}
