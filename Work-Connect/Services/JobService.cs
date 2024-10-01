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

        public async Task<List<Job>> SearchJobsBySkills(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                // Return all jobs if the search query is empty
                return await _context.Jobs.ToListAsync();
            }

            // Search for jobs containing the specified skills
            return await _context.Jobs
                .Where(j => j.Skills.Contains(searchQuery))
                .ToListAsync();
        }
    }
}
