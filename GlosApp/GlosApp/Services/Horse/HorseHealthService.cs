using GlosApp.Data;
using GlosApp.Models.Horse;
using Microsoft.EntityFrameworkCore;

namespace GlosApp.Services.Horse
{
    public class HorseHealthService
    {
        private readonly ApplicationDbContext _context;

        public HorseHealthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HorseHealthStatus> GetHealthStatusAsync()
        {
            return await _context.HorseHealthStatuses.FirstOrDefaultAsync() ?? new HorseHealthStatus();
        }

        public async Task UpdateHealthStatusAsync(HorseHealthStatus status)
        {
            var existingStatus = await _context.HorseHealthStatuses.FirstOrDefaultAsync();
            if (existingStatus == null)
            {
                _context.HorseHealthStatuses.Add(status);
            }
            else
            {
                existingStatus.StatusText = status.StatusText;
                existingStatus.Color = status.Color;
            }
            await _context.SaveChangesAsync();
        }
    }

}
