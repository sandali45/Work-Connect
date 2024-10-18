using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Connect.Data; 
using Work_Connect.Models;

namespace Work_Connect.Services 
{
    public class JobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to search jobs by skills or keywords
        public async Task<List<postAJob>> SearchJobsBySkills(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return await _context.postAJob.ToListAsync(); // Return all jobs if no search query
            }

            return await _context.postAJob
                .Where(job => job.JobTitle.Contains(searchQuery) ||
                              job.CompanyName.Contains(searchQuery) ||
                              job.JobDescription.Contains(searchQuery))
                .ToListAsync(); // Filter jobs based on title, company, or description
        }
    }
}
