using GlosApp.Data;
using GlosApp.Models.Horse;
using Microsoft.EntityFrameworkCore;

namespace GlosApp.Services.Horse
{
    public class HorseDiaryService
    {
        private readonly ApplicationDbContext _context;

        public HorseDiaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HorseDiaryEntry>> GetEntriesAsync()
        {
            return await _context.HorseDiaryEntries
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        public async Task AddEntryAsync(HorseDiaryEntry entry)
        {
            _context.HorseDiaryEntries.Add(entry);
            await _context.SaveChangesAsync();
        }
    }

}
